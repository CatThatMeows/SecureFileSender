using Newtonsoft.Json;
using System.Text;

namespace FileSender.Core.Packets
{
    public class Packet
    {
        [JsonIgnore]
        public PacketType PacketType { get; set; }
        [JsonIgnore]
        public long Size { get; set; }
        public byte[] Serialize()
        {
            string packetString = JsonConvert.SerializeObject(this);
            this.Size = UTF8Encoding.UTF8.GetByteCount(packetString);
            return UTF8Encoding.UTF8.GetBytes(packetString);
        }
    }
    public enum PacketType : byte
    {
        AuthPacket = 0,
        FileListPacket = 64,
        FileListPacketRequest = 65,
        FileDownloadRequest = 128,
        InvalidPacket = 255
    }
}
