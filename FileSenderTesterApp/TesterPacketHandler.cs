using FileSender.Core.Network;
using FileSender.Core.Packets;
using System.Text;


namespace FileSenderTesterApp
{
    internal class TesterClientPacketHandler : PacketHandler
    {
        public EventHandler onMessageReceived { get; set; }
        public async Task Handle(NetworkCore con, PacketType packetType, ArraySegment<byte> bytes)
        {
            if (onMessageReceived != null)
            {
                string response = UTF8Encoding.UTF8.GetString(bytes);
                onMessageReceived?.Invoke(response, null);
            }
        }
    }
}
