using System;
using System.Text;

namespace CryptographyInDotNet
{
    class Program
    {
        static void Main()
        {                                
            const string original = "Very secret and important information that can not fall into the wrong hands.";

            var rsaParams = new RsaWithRsaParameterKey();
            rsaParams.AssignNewKey();

            var hybrid = new HybridEncryption();

            var encryptedBlock = hybrid.EncryptData(Encoding.UTF8.GetBytes(original), rsaParams);
            var decrpyted = hybrid.DecryptData(encryptedBlock, rsaParams);

            Console.WriteLine("Hybrid Encryption Demonstration in .NET");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Original Message = " + original);
            Console.WriteLine();
            Console.WriteLine("Message After Decryption = " + Encoding.UTF8.GetString(decrpyted));
            Console.ReadLine();
        }
    }
}
