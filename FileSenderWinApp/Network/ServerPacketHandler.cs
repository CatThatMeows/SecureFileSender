using FileSender.Core.Network;
using FileSender.Core.Network.Server;
using FileSender.Core.Packets;
using FileSender.Core.UI;
using Newtonsoft.Json;
using System.Text;

namespace FileSenderWinApp.Network
{
    public class ServerPacketHandler : PacketHandler
    {
        public async Task Handle(NetworkCore con, PacketType packetType, ArraySegment<byte> bytes)
        {
            if(packetType == PacketType.AuthPacket)
            {
                AuthPacket ap = JsonConvert.DeserializeObject<AuthPacket>(UTF8Encoding.UTF8.GetString(bytes));
                if (ap == null)
                {
                    await con.Disconnect();
                    return;
                }
                ((ClientNode)con).FullID = ap.ID;
            }
            else if(packetType == PacketType.FileListPacketRequest)
            {
                await con.SendCMD(FileListPacket.CreateFileList());
            }
            else if(packetType == PacketType.FileDownloadRequest)
            {
                FileDownloadRequest req = JsonConvert.DeserializeObject<FileDownloadRequest>(UTF8Encoding.UTF8.GetString(bytes));
                if(req == null)
                {
                    await con.Disconnect();
                    return;
                }
                for(int i = 0; i < FileData.ServerFiles.Count; i++)
                {
                    if (FileData.ServerFiles[i].ID == req.FileID)
                    {
                        if (FileData.ServerFiles[i].IsPassworded)
                        {
                            if (FileData.ServerFiles[i].PasswordHash == req.ReqPasswordHash)
                            {
                                _ = ((ClientNode)con).SendFile(FileData.ServerFiles[i]);
                            }
                            else
                            {
                                //Disconnect
                                await con.Disconnect();
                                return;
                            }
                        }
                        else
                            _ = ((ClientNode)con).SendFile(FileData.ServerFiles[i]);
                    }
                }
            }
        }
    }
}
