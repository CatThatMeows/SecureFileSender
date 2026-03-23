using FileSender.Core.Client;
using FileSender.Core.Network;
using FileSender.Core.Network.Server;
using FileSender.Core.Packets;
using FileSender.Core.UI;
using FileSenderWinApp.Forms;
using FileSenderWinApp.Forms.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                ((ClientNode)con).FullID = ap.ID;
               //await con.SendCMD(new FileListPacket());
            }
            else if(packetType == PacketType.FileListPacketRequest)
            {
                await con.SendCMD(FileListPacket.CreateFileList());
            }
            else if(packetType == PacketType.FileDownloadRequest)
            {
                FileDownloadRequest req = JsonConvert.DeserializeObject<FileDownloadRequest>(UTF8Encoding.UTF8.GetString(bytes));
                for(int i = 0; i < FileData.ServerFiles.Count; i++)
                {
                    if (FileData.ServerFiles[i].ID == req.FileID)
                    {
                        //Do something with this later
                        _ = ((ClientNode)con).SendFile(FileData.ServerFiles[i]);
                    }
                }
            }
        }
    }
}
