using FileSender.Core.Tools;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

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
            if (!string.IsNullOrWhiteSpace(Path)) {
                if(Path != Directory.GetCurrentDirectory() + "\\" + CertificatePath)
                    File.Copy(Path, CertificatePath, true);
                SetCertificate(new X509Certificate2(CertificatePath, password));
                return true;
            }
            else if (!string.IsNullOrWhiteSpace(CertificatePath))
            {
                SetCertificate(new X509Certificate2(CertificatePath, password));
                return true;
            }

            return false;
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
        }
        public void CoreInit()
        {
            if(File.Exists("config.json"))
                CoreSettingsImport();
        }
    }
}
