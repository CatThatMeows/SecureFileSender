namespace FileSender.Core.Packets
{
    public class AuthPacket : Packet
    {
        public Guid ID { get; private set; }
        public AuthPacket() {
            ID = Guid.NewGuid();
            PacketType = PacketType.AuthPacket;
        }
    }
}
