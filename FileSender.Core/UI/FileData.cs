using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text;

namespace FileSender.Core.UI
{
    public class FileData
    {
        public static List<FileData> ServerFiles { get; set; } = new List<FileData>();
        public static List<FileData> ClientFiles { get; set; } = new List<FileData>();

        public static void AddToServerFiles(FileData data)
        {
            ServerFiles.Add(data);
            WriteToFile();
        }

        public static void WriteToFile()
        {
            File.WriteAllText
                ("ServerFiles.json", JsonConvert.SerializeObject(ServerFiles));
        }

        public static void InitLists()
        {
            if (File.Exists("ServerFiles.json"))
            {
                List<FileData> loadedFile = JsonConvert.DeserializeObject<List<FileData>>(File.ReadAllText("ServerFiles.json"));
                if (loadedFile != null)
                    ServerFiles = loadedFile;
            }
            if (File.Exists("ClientFiles.json"))
            {
                List<FileData> loadedFile = JsonConvert.DeserializeObject<List<FileData>>(File.ReadAllText("ServerFiles.json"));
                if (loadedFile != null)
                    ClientFiles = loadedFile;
            }
        }

        public void SetPassword(string password)
        {
            IsPassworded = true;
            byte[] hashedPass = SHA512.HashData(Encoding.UTF8.GetBytes(password));
            PasswordHash = Convert.ToHexString(hashedPass);
        }

        public Guid ID { get; set; }
        public string FileName { get; set; } = string.Empty; //Full name including extension
        public string FileLocation { get; set; } = string.Empty; //File full location
        public string PasswordHash { get; set; } = string.Empty;
        public bool IsPassworded { get; set; } = false;
        public long FileSize { get; set; }
    }
}
