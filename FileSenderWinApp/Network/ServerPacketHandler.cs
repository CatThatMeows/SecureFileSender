using FileSender.Core.Client;
using FileSender.Core.Network;
using FileSender.Core.Network.Server;
using FileSender.Core.Packets;
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
               //await con.SendCMD(new FileListPacket());
            }
            else if(packetType == PacketType.FileListPacketRequest)
            {
                await con.SendCMD(new FileListPacket());
            }
        }
    }
}
