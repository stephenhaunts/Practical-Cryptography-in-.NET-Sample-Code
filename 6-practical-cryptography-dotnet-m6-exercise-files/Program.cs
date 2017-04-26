using System;
using System.Text;

namespace CryptographyInDotNet
{
    class Program
    {
        static void Main()
        {
           // RsaWithRsaParameterKey();
           // RsaWithXml();
            RsaWithCsp();
                     
            Console.ReadLine();
        }

        private static void RsaWithXml()
        {
            var rsa = new RsaWithXmlKey();

            const string original = "Text to encrypt";
            const string publicKeyPath = "c:\\temp\\publickey.xml";
            const string privateKeyPath = "c:\\temp\\privatekey.xml";

            rsa.AssignNewKey(publicKeyPath, privateKeyPath);
            var encrypted = rsa.EncryptData(publicKeyPath, Encoding.UTF8.GetBytes(original));
            var decrypted = rsa.DecryptData(privateKeyPath, encrypted);

            Console.WriteLine("Xml Based Key");
            Console.WriteLine();
            Console.WriteLine("   Original Text = " + original);
            Console.WriteLine();
            Console.WriteLine("   Encrypted Text = " + Convert.ToBase64String(encrypted));
            Console.WriteLine();
            Console.WriteLine("   Decrypted Text = " + Encoding.Default.GetString(decrypted));
            Console.WriteLine();
        }

        private static void RsaWithCsp()
        {
            var rsaCsp = new RsaWithCspKey();
            const string original = "Text to encrypt";

            rsaCsp.AssignNewKey();

            var encryptedCsp = rsaCsp.EncryptData(Encoding.UTF8.GetBytes(original));
            var decryptedCsp = rsaCsp.DecryptData(encryptedCsp);

            rsaCsp.DeleteKeyInCsp();

            Console.WriteLine();
            Console.WriteLine("CSP Based Key");
            Console.WriteLine();
            Console.WriteLine("   Original Text = " + original);
            Console.WriteLine();
            Console.WriteLine("   Encrypted Text = " + Convert.ToBase64String(encryptedCsp));
            Console.WriteLine();
            Console.WriteLine("   Decrypted Text = " + Encoding.Default.GetString(decryptedCsp));
        }

        private static void RsaWithRsaParameterKey()
        {
            var rsaParams = new RSAWithRSAParameterKey();
            const string original = "Text to encrypt";

            rsaParams.AssignNewKey();

            var encryptedRsaParams = rsaParams.EncryptData(Encoding.UTF8.GetBytes(original));
            var decryptedRsaParams = rsaParams.DecryptData(encryptedRsaParams);


            Console.WriteLine("RSA Encryption Demonstration in .NET");
            Console.WriteLine("------------------------------------");
            Console.WriteLine();
            Console.WriteLine("In Memory Key");
            Console.WriteLine();
            Console.WriteLine("   Original Text = " + original);
            Console.WriteLine();
            Console.WriteLine("   Encrypted Text = " + Convert.ToBase64String(encryptedRsaParams));
            Console.WriteLine();
            Console.WriteLine("   Decrypted Text = " + Encoding.Default.GetString(decryptedRsaParams));
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
