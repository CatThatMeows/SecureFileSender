using FileSender.Core.Tools;
using Newtonsoft.Json;
using System.Security.Cryptography.X509Certificates;

namespace FileSender.Core
{
    public class CoreSettings
    {
        private static CoreSettings _CS = new CoreSettings();
        public static CoreSettings CS { get { return _CS; } }
        [JsonIgnore]
        public X509Certificate2 ServerCertificate { get; private set; }
        public string CertificatePath { get; set; } = "cert.p12";
        public int Port { get; set; }

        public bool ImportCertificate(string password, string Path = null)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(Path))
                {
                    if (Path != Directory.GetCurrentDirectory() + "\\" + CertificatePath)
                        File.Copy(Path, CertificatePath, true);
                    SetCertificate(LoadCertificate(password));
                    return true;
                }
                else if (!string.IsNullOrWhiteSpace(CertificatePath))
                {
                    SetCertificate(LoadCertificate(password));
                    return true;
                }
            }
            catch (Exception ex) { return false; }
            return false;
        }

        private X509Certificate2 LoadCertificate(string password)
        {
            return X509CertificateLoader.LoadPkcs12FromFile(CertificatePath, password);
        }
        
        public void SetCertificate(X509Certificate2 cert)
        {
            ServerCertificate = cert;
            CoreSettingsExport();
        }
        public void CreateNewCert(string caName, string password)
        {
            X509Certificate2 cert = CreateSelfSignedCert.CreateCert(caName);
            ExportCertificate(cert, password);

        }
        private void ExportCertificate(X509Certificate2 cert, string password)
        {
            File.WriteAllBytes(CertificatePath, cert.Export(X509ContentType.Pkcs12, password));
        }
        public void SetPort(int port)
        {
            Port = port;
            CoreSettingsExport();
        }
        public void CoreSettingsExport()
        {
            File.WriteAllText
                ("config.json", JsonConvert.SerializeObject(this));
        }
        private void CoreSettingsImport()
        {
            _CS = JsonConvert.DeserializeObject<CoreSettings>(File.ReadAllText("config.json"));
            if(_CS == null)
            {
                _CS = new CoreSettings();
            }
        }
        public void CoreInit()
        {
            if(File.Exists("config.json"))
                CoreSettingsImport();
        }
    }
}
