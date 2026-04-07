using Org.BouncyCastle.Security;

namespace FileSender.Core.Packets
{
    public class FileDownloadRequest : Packet
    {
        public Guid FileID { get; set; }
        public string ReqPasswordHash { get; set; }
        public FileDownloadRequest(Guid _FileID, string password = "")
        {
            PacketType = PacketType.FileDownloadRequest;
            FileID = _FileID;
            ReqPasswordHash = password;
        }
    }
}
