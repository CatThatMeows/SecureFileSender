using FileSender.Core.UI;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FileSender.Core.Packets
{
    public class FileListPacket : Packet
    {
        public List<FileData> Files { get; set; }
        public static FileListPacket CreateFileList() {
            FileListPacket flp = new FileListPacket() {
                Files = UI.FileData.ServerFiles,
                PacketType = PacketType.FileListPacket
            };
            return flp;
        }
    }
    public class ConditionalPropertiesResolver : DefaultContractResolver
    {
        private readonly bool IncludeSensitive;

        public ConditionalPropertiesResolver(bool _IncludeSensitive)
        {
            IncludeSensitive = _IncludeSensitive;
        }

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty prop = base.CreateProperty(member, memberSerialization);

            if (!IncludeSensitive && (prop.PropertyName == nameof(FileData.FileLocation)
                                       || prop.PropertyName == nameof(FileData.PasswordHash)))
            {
                prop.Ignored = true;
            }

            return prop;
        }
    }
}
