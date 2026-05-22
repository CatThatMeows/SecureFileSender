using FileSender.Core.Client;
using FileSender.Core.Packets;
using FileSender.Core.Tools;
using System.Text;

namespace FileSenderTesterApp
{
    public partial class TestConnection : Connection
    {
        public async Task SendTestCMD(string input, PacketType _packetType)
        {
            byte[] send = await GZip.CompressData(UTF8Encoding.UTF8.GetBytes(input), CTS.Token);
            byte[] packetType = new byte[1] { (byte)_packetType };
            await SSLStream.WriteAsync(BitConverter.GetBytes(send.LongLength), CTS.Token);
            await SSLStream.WriteAsync(packetType, CTS.Token);
            await SSLStream.WriteAsync(send, CTS.Token);
        }
    }
}
