using FileSender.Core.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSender.Core.Packets
{
    public class FileListPacket : Packet
    {
        public List<FileData> Files { get; set; }
        public FileListPacket() {
            Files = UI.FileData.ServerFiles;
            PacketType = PacketType.FileListPacket;
        }
    }
}
