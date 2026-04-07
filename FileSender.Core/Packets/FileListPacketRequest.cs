using System;
using System.Collections.Generic;
using System.Text;

namespace FileSender.Core.Packets
{
    public class FileListPacketRequest : Packet
    {
        public FileListPacketRequest()
        {
            PacketType = PacketType.FileListPacketRequest;
        }
    }
}
