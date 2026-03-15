namespace FileSender.Core.Packets
{
    public class FileDownloadRequest : Packet
    {
        public Guid FileID { get; set; }
        public int ChunkSize { get; set; }
        public FileDownloadRequest(Guid ID)
        {
            PacketType = PacketType.FileDownloadRequest;
            FileID = ID;
            ChunkSize = 32768;
        }
    }
}
