namespace FileSender.Core.Packets
{
    public class FileDownloadRequest : Packet
    {
        public Guid FileID { get; set; }
        public FileDownloadRequest(Guid _FileID)
        {
            PacketType = PacketType.FileDownloadRequest;
            FileID = _FileID;
        }
    }
}
