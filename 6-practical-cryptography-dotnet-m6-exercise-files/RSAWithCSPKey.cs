using System.Security.Cryptography;

namespace CryptographyInDotNet
{
    public class RsaWithCspKey 
    {
        const string ContainerName = "MyContainer";

        public void AssignNewKey()
        {
            CspParameters cspParams = new CspParameters(1);
            cspParams.KeyContainerName = ContainerName;
            cspParams.Flags = CspProviderFlags.UseMachineKeyStore;
            cspParams.ProviderName = "Microsoft Strong Cryptographic Provider";

            var rsa = new RSACryptoServiceProvider(cspParams) { PersistKeyInCsp = true };
        }

        public void DeleteKeyInCsp()
        {
            var cspParams = new CspParameters { KeyContainerName = ContainerName };
            var rsa = new RSACryptoServiceProvider(cspParams) { PersistKeyInCsp = false };

            rsa.Clear();                         
        }

        public byte[] EncryptData(byte[] dataToEncrypt)
        {
            byte[] cipherbytes;

            var cspParams = new CspParameters { KeyContainerName = ContainerName };

            using (var rsa = new RSACryptoServiceProvider(2048, cspParams))
            {
                cipherbytes = rsa.Encrypt(dataToEncrypt, false);
            }

            return cipherbytes;
        }

        public byte[] DecryptData(byte[] dataToDecrypt)
        {
            byte[] plain;

            var cspParams = new CspParameters { KeyContainerName = ContainerName };

            using (var rsa = new RSACryptoServiceProvider(2048, cspParams))
            {                               
                plain = rsa.Decrypt(dataToDecrypt, false);
            }

            return plain;
        }
    }
}