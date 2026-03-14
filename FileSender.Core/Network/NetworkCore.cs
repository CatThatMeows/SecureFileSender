using FileSender.Core.Packets;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        internal int BytesToReceive = 9;

        internal long BytesToReceiveFull = 9;
        internal long BytesToReceiveFullND = 9;

        internal bool ReceivingHeaderData = true;

        internal byte[] Buffer = new byte[16384];

        internal byte PacketRead { get; set; }

        public CancellationToken CT { get; set; }
        public PacketHandler PacketHandler { get; set; }
        public bool IsServer { get; set; }

        public async Task ReceiveData()
        {
            while (!CT.IsCancellationRequested)
            {
                int read = await SSLStream.ReadAsync(Buffer, BufferIndex, BytesToReceive, CT);
                Debug.WriteLine("Read: " + read);
                if (read > 0)
                {
                    BufferIndex += read;
                    BytesToReceiveFull -= read;
                    BytesToReceive -= read;
                    Debug.WriteLine(BytesToReceiveFull);
                    if (BytesToReceiveFull == 0)
                    {
                        if (ReceivingHeaderData)
                        {
                            long receivedBytes = BitConverter.ToInt64(Buffer, 0);
                            PacketRead = Buffer[8];
                            Debug.WriteLine("PacketType: " + PacketRead);
                            Debug.WriteLine("Bytes to receive next: " + receivedBytes);
                            if (receivedBytes > 0)
                            {
                                BufferIndex = 0;
                                ReceivingHeaderData = false;
                                BytesToReceiveFull = receivedBytes;
                                BytesToReceiveFullND = BytesToReceiveFull;
                                if (BytesToReceiveFull > 16384)
                                    BytesToReceive = 16384;
                                else
                                    BytesToReceive = (int)BytesToReceiveFull;
                            }
                            else
                            {
                                //Disconnect
                            }
                        }
                        else
                        {
                            //Receive data
                            Debug.WriteLine("We have received all data????");
                            ArraySegment<byte> segment = new ArraySegment<byte>(Buffer, 0, (int)BytesToReceiveFullND);
                            await PacketHandler.Handle(this, (PacketType)PacketRead, segment);

                            //Reset variables
                            BufferIndex = 0;
                            BytesToReceive = 9;
                            BytesToReceiveFull = 9;
                            BytesToReceiveFullND = 9;
                            ReceivingHeaderData = true;
                        }
                    }
                }
                else
                {
                    //Disconnect
                }
            }
        }

        public async Task<bool> SendCMD(Packet packet)
        {
            //TEST
            try
            {
                byte[] packetBytes = packet.Serialize();
                byte[] packetType = new byte[1];
                packetType[0] = (byte)packet.PacketType;
                Debug.WriteLine("packet size: " + packet.Size);
                await SSLStream.WriteAsync(BitConverter.GetBytes(packet.Size), CT);
                await SSLStream.WriteAsync(packetType, CT);
                await SSLStream.WriteAsync(packetBytes, CT);
            }
            catch (Exception ex)
            {
                //Disconnect

                return false;
            }

            return true;
        }
    }
}
