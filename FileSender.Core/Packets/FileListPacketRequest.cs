using Newtonsoft.Json;

namespace FileSender.Core.Packets
{
    public class FileListPacketRequest : Packet
    {
        [JsonIgnore]
        public const string Template = "{}";
        public FileListPacketRequest()
        {
            PacketType = PacketType.FileListPacketRequest;
        }
    }
}
