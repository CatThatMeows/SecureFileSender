using FileSender.Core.Packets;

namespace FileSender.Core.Network
{
    public interface PacketHandler
    {
        Task Handle(NetworkCore con, PacketType packetType, ArraySegment<byte> bytes);
    }
}
