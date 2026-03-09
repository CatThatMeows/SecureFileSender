using FileSender.Core.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSender.Core.Packets
{
    internal class FileListPacket
    {
        public List<FileData> Files { get; set; }
    }
}
