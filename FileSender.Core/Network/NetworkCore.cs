using FileSender.Core.Packets;
using FileSender.Core.Tools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Compression;
using System.Net.Security;
using System.Net.Sockets;
using System.Text;

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

        public CancellationToken CT { get; set; }
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
            while (!CT.IsCancellationRequested)
            {
                long bytesToReceive = await ReceiveHeader();
                if(bytesToReceive == -1) { return; } //Change to disconnect properly later
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
            while (!CT.IsCancellationRequested)
            {
                int read = await SSLStream.ReadAsync(Buffer, BufferIndex, BytesToReceive, CT);
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
            await PacketHandler.Handle(this, (PacketType)PacketRead, await GZip.DecompressData(segment, CT));
        }

        private async Task<long> ReceiveHeader()
        {
            BufferIndex = 0;
            BytesToReceive = 9; BytesToReceiveFull = 9; BytesToReceiveFullND = 9;

            while (!CT.IsCancellationRequested)
            {
                int read = await SSLStream.ReadAsync(Buffer, BufferIndex, BytesToReceive, CT);

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
                byte[] compressedPacketBytes = await GZip.CompressData(packet.Serialize(), CT);
                byte[] packetType = new byte[1];
                packetType[0] = (byte)packet.PacketType;
                await SSLStream.WriteAsync(BitConverter.GetBytes(compressedPacketBytes.LongLength), CT);
                await SSLStream.WriteAsync(packetType, CT);
                await SSLStream.WriteAsync(compressedPacketBytes, CT);
            }
            catch (Exception ex)
            {
                //Disconnect
                Debug.WriteLine(ex.Message);
                return false;
            }

            return true;
        }
    }
}
