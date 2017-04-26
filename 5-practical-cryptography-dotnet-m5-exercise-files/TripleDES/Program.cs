using System;
using System.Text;

namespace CryptographyInDotNet
{
    class Program
    {
        static void Main()
        {
            var trippleDes = new TripleDesEncryption();
            
            //var key = trippleDes.GenerateRandomNumber(24);
            var key = trippleDes.GenerateRandomNumber(16);

            var iv = trippleDes.GenerateRandomNumber(8);
            const string original = "Text to encrypt";

            var encrypted = trippleDes.Encrypt(Encoding.UTF8.GetBytes(original), key, iv);
            var decrypted = trippleDes.Decrypt(encrypted, key, iv);

            var decryptedMessage = Encoding.UTF8.GetString(decrypted);

            Console.WriteLine("Triple DES Encryption Demonstration in .NET");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Original Text = " + original);
            Console.WriteLine("Encrypted Text = " + Convert.ToBase64String(encrypted));
            Console.WriteLine("Decrypted Text = " + decryptedMessage);
            
            Console.ReadLine();
        }
    }
}
