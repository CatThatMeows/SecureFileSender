using Newtonsoft.Json;

namespace FileSender.Core.Packets
{
    public class FileDownloadRequest : Packet
    {
        [JsonIgnore]
        public const string Template = @"{""FileID"":""ebb1ea09-0e40-44d2-b837-791037dad0f9"",""ReqPasswordHash"":""""}";
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
