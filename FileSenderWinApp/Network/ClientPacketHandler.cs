using FileSender.Core.Client;
using FileSender.Core.Network;
using FileSender.Core.Packets;
using FileSenderWinApp.Forms;
using FileSenderWinApp.Forms.Client;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;

namespace FileSenderWinApp.Network
{
    public class ClientPacketHandler : PacketHandler
    {
        public async Task Handle(NetworkCore con, PacketType packetType, ArraySegment<byte> bytes)
        {
            //Debug.WriteLine(UTF8Encoding.UTF8.GetString(bytes)); //DEBUG
            if (packetType == PacketType.FileListPacket)
            {
                FileListPacket packet = JsonConvert.DeserializeObject<FileListPacket>(UTF8Encoding.UTF8.GetString(bytes));
                if(packet == null)
                {
                    await con.Disconnect();
                    return;
                }
                ((ClientServerFileList)FormHandler.ClientServerFileList).AddFiles(packet.Files);
            }
            else
            {
                
            }
        }
    }
}
