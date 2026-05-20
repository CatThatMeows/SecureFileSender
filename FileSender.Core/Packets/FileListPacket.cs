using FileSender.Core.UI;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Reflection;

namespace FileSender.Core.Packets
{
    public class FileListPacket : Packet
    {
        [JsonIgnore]
        public const string Template = @"{
  ""Files"": [
    {
      ""ID"": ""4a545506-8b03-4119-8bb1-a04bada0fee4"",
      ""FileName"": ""VÉN HÜLYE BUZERÁNSOK - Lil Kubik a Creeper.mp3"",
      ""IsPassworded"": true,
      ""FileSize"": 6639564
    },
    {
      ""ID"": ""ebb1ea09-0e40-44d2-b837-791037dad0f9"",
      ""FileName"": ""models2.pack"",
      ""IsPassworded"": false,
      ""FileSize"": 2020165380
    }
  ]
}";
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
