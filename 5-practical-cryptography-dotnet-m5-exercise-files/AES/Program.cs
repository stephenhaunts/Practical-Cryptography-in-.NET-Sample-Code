using System;
using System.Text;

namespace CryptographyInDotNet
{
    class Program
    {
        static void Main()
        {           
            var aes = new AesEncryption();
            var key = aes.GenerateRandomNumber(32);
            var iv = aes.GenerateRandomNumber(16);
            const string original = "Text to encrypt";

            var encrypted = aes.Encrypt(Encoding.UTF8.GetBytes(original), key, iv);
            var decrypted = aes.Decrypt(encrypted, key, iv);

            var decryptedMessage = Encoding.UTF8.GetString(decrypted);

            Console.WriteLine("AES Encryption Demonstration in .NET");
            Console.WriteLine("------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Original Text = " + original);
            Console.WriteLine("Encrypted Text = " + Convert.ToBase64String(encrypted));
            Console.WriteLine("Decrypted Text = " + decryptedMessage);
            
            Console.ReadLine();
        }
    }
}
