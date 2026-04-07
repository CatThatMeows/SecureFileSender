using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Operators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Prng;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.X509;
using Org.BouncyCastle.X509.Extension;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace FileSender.Core.Tools
{
    // <- , -> , <-
    internal class CreateSelfSignedCert
    {
        public static X509Certificate2 CreateCert(string caName)
        {
            SecureRandom sRand = new SecureRandom(new CryptoApiRandomGenerator());
            RsaKeyPairGenerator keyPairGen = new RsaKeyPairGenerator();
            keyPairGen.Init(new KeyGenerationParameters(sRand, 2048));

            AsymmetricCipherKeyPair keypair = keyPairGen.GenerateKeyPair();

            X509V3CertificateGenerator certificateGenerator = new X509V3CertificateGenerator();

            X509Name CN = new X509Name("CN=" + caName);
            Org.BouncyCastle.Math.BigInteger SN = Org.BouncyCastle.Math.BigInteger.ProbablePrime(120, sRand);

            certificateGenerator.SetSerialNumber(SN);
            certificateGenerator.SetSubjectDN(CN);
            certificateGenerator.SetIssuerDN(CN);
            certificateGenerator.SetNotAfter(DateTime.MaxValue);
            certificateGenerator.SetNotBefore(DateTime.UtcNow.Subtract(new TimeSpan(2, 0, 0, 0)));
            certificateGenerator.SetPublicKey(keypair.Public);
            certificateGenerator.AddExtension(X509Extensions.SubjectKeyIdentifier, false, new SubjectKeyIdentifierStructure(keypair.Public));
            certificateGenerator.AddExtension(X509Extensions.BasicConstraints, true, new BasicConstraints(true));

            ISignatureFactory signatureFactory = new Asn1SignatureFactory("SHA512WITHRSA", keypair.Private, sRand);

            Org.BouncyCastle.X509.X509Certificate certificate = certificateGenerator.Generate(signatureFactory);

            X509Certificate2 certificate2 = new X509Certificate2(DotNetUtilities.ToX509Certificate(certificate));
            X509Certificate2 result;

            using (RSA rsaPrivate = DotNetUtilities.ToRSA(keypair.Private as RsaPrivateCrtKeyParameters))
            {
                result = certificate2.CopyWithPrivateKey(rsaPrivate);
            }

            return result;
        }
    }
}
