using Newtonsoft.Json;

namespace FileSender.Core.UI
{
    public class FileData
    {
        public static List<FileData> ServerFiles { get; set; } = new List<FileData>();
        public static List<FileData> ClientFiles { get; set; } = new List<FileData>();

        public static void AddToServerFiles(FileData data)
        {
            ServerFiles.Add(data);
            File.WriteAllText
                ("ServerFiles.json", JsonConvert.SerializeObject(ServerFiles));
        }

        public static void InitLists()
        {
            if (File.Exists("ServerFiles.json"))
            {
                ServerFiles = JsonConvert.DeserializeObject<List<FileData>>(File.ReadAllText("ServerFiles.json"));
            }
            if (File.Exists("ClientFiles.json"))
            {
                ClientFiles = JsonConvert.DeserializeObject<List<FileData>>(File.ReadAllText("ServerFiles.json"));
            }
        }

        public string FileName { get; set; } //Full name including extension
        public string FileLocation { get; set; } //File full location
        public long FileSize { get; set; }
    }
}
