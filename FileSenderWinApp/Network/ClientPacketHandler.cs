using FileSender.Core.Client;
using FileSender.Core.Network;
using FileSender.Core.Network.Server;
using FileSender.Core.Packets;
using FileSenderWinApp.Forms;
using FileSenderWinApp.Forms.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileSenderWinApp.Network
{
    internal class ClientPacketHandler : PacketHandler
    {
        public async Task Handle(NetworkCore con, PacketType packetType, ArraySegment<byte> bytes)
        {
            if (packetType == PacketType.FileListPacket)
            {
                FileListPacket packet = JsonConvert.DeserializeObject<FileListPacket>(UTF8Encoding.UTF8.GetString(bytes));
                ((ClientServerFileList)FormHandler.ClientServerFileList).AddFiles(packet.Files);
            }
            else
            {
                
            }
        }
    }
}
