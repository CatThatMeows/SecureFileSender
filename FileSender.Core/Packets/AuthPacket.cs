using Newtonsoft.Json;

namespace FileSender.Core.Packets
{
    public class AuthPacket : Packet
    {
        [JsonIgnore]
        public const string Template = @"{""ID"":""65add525-92c7-46aa-a068-d944ce12df45""}";
        public Guid ID { get; private set; }
        public AuthPacket() {
            ID = Guid.NewGuid();
            PacketType = PacketType.AuthPacket;
        }
    }
}
