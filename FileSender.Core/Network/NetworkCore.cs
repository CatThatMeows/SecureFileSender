using FileSender.Core.Packets;
using FileSender.Core.Tools;
using FileSender.Core.UI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Compression;
using System.Net.Security;
using System.Net.Sockets;
using System.Text;
using System.Text.Json.Serialization;

namespace FileSender.Core.Network
{
    public class NetworkCore
    {
        internal Socket ClientSocket { get; set; }
        internal SslStream SSLStream { get; set; }

        internal const int HeaderSize = 9;

        internal int BufferIndex = 0;
        internal int BytesToReceive = 0;

        internal long BytesToReceiveFull = 0;
        internal long BytesToReceiveFullND = 0;

        internal bool ReceivingHeaderData = true;

        internal const int BufferSize = 16384;
        internal byte[] Buffer = new byte[BufferSize];

        internal byte PacketRead { get; set; }

        public CancellationTokenSource CTS { get; set; }
        public PacketHandler PacketHandler { get; set; }
        public bool IsServer { get; set; }
        public bool IsConnected 
        { 
            get
            {
                return ClientSocket.Connected;
            } 
        }

        public async Task ReceiveData()
        {
            while (!CTS.IsCancellationRequested)
            {
                long bytesToReceive = await ReceiveHeader();
                if(bytesToReceive == -1) { await Disconnect(); }
                BytesToReceiveFull = bytesToReceive;
                BytesToReceiveFullND = bytesToReceive;
                if (BytesToReceiveFull <= 16384)
                    BytesToReceive = (int)bytesToReceive;
                else
                    BytesToReceive = 16384;
                BufferIndex = 0;

                await ReceiveCMD();
            }
        }

        private async Task ReceiveCMD()
        {
            while (!CTS.IsCancellationRequested)
            {
                int read = await SSLStream.ReadAsync(Buffer, BufferIndex, BytesToReceive, CTS.Token);
                BytesToReceiveFull -= read;
                BytesToReceive -= read;
                BufferIndex += read;

                if(BytesToReceive == 0)
                {
                    break;
                }
                //ToDo: Handle 16kb+ commands, in case file list is long af
            }

            ArraySegment<byte> segment = new ArraySegment<byte>(Buffer, 0, (int)BytesToReceiveFullND);
            await PacketHandler.Handle(this, (PacketType)PacketRead, await GZip.DecompressData(segment, CTS.Token));
        }

        private async Task<long> ReceiveHeader()
        {
            BufferIndex = 0;
            BytesToReceive = 9; BytesToReceiveFull = 9; BytesToReceiveFullND = 9;

            while (!CTS.IsCancellationRequested)
            {
                int read = await SSLStream.ReadAsync(Buffer, BufferIndex, BytesToReceive, CTS.Token);

                BufferIndex += read;
                BytesToReceiveFull -= read;
                BytesToReceive -= read;

                if(BytesToReceiveFull == 0)
                {
                    long receivedBytes = BitConverter.ToInt64(Buffer, 0);
                    PacketRead = Buffer[8];
                    if(receivedBytes > 0)
                    {
                        return receivedBytes;
                    }
                    else
                    {
                        return -1;
                    }
                }
            }

            return -1;
        }
        public async Task<bool> SendCMD(Packet packet)
        {
            //TEST
            try
            {
                byte[] compressedPacketBytes;
                if (packet.PacketType == PacketType.FileListPacket)
                {
                    JsonSerializerSettings settings = new JsonSerializerSettings()
                    {
                        ContractResolver = new ConditionalPropertiesResolver(false),
                        Formatting = Formatting.Indented
                    };
                    string data = JsonConvert.SerializeObject((FileListPacket)packet, settings);
                    compressedPacketBytes = await GZip.CompressData(UTF8Encoding.UTF8.GetBytes(data), CTS.Token);
                }
                else
                  compressedPacketBytes = await GZip.CompressData(packet.Serialize(), CTS.Token);
                byte[] packetType = new byte[1] { (byte)packet.PacketType };
                await SSLStream.WriteAsync(BitConverter.GetBytes(compressedPacketBytes.LongLength), CTS.Token);
                await SSLStream.WriteAsync(packetType, CTS.Token);
                await SSLStream.WriteAsync(compressedPacketBytes, CTS.Token);
            }
            catch (Exception ex)
            {
                //Disconnect
                await Disconnect();
                return false;
            }

            return true;
        }

        public async Task Disconnect()
        {
            try
            {
                await CTS.CancelAsync();
                SSLStream.Close();
                ClientSocket.Shutdown(SocketShutdown.Both);
                ClientSocket.Close();
                ClientSocket.Dispose();
            }catch { }
        }
    }
}
