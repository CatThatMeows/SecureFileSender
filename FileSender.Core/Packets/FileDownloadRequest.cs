namespace FileSender.Core.Packets
{
    public class FileDownloadRequest : Packet
    {
        public Guid ClientID { get; set; }
        public Guid FileID { get; set; }
        public FileDownloadRequest(Guid ID)
        {
            PacketType = PacketType.FileDownloadRequest;
            FileID = ID;
        }
    }
}
