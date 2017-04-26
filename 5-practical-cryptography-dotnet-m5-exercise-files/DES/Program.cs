using System;
using System.Text;

namespace CryptographyInDotNet
{
    class Program
    {
        static void Main()
        {
            var des = new DesEncryption();
            var key = des.GenerateRandomNumber(8);
            var iv = des.GenerateRandomNumber(8);
            const string original = "Text to encrypt";

            var encrypted = des.Encrypt(Encoding.UTF8.GetBytes(original), key, iv);
            var decrypted = des.Decrypt(encrypted, key, iv);

            var decryptedMessage = Encoding.UTF8.GetString(decrypted);

            Console.WriteLine("DES Encryption Demonstration in .NET");
            Console.WriteLine("------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Original Text = " + original);
            Console.WriteLine("Encrypted Text = " + Convert.ToBase64String(encrypted));
            Console.WriteLine("Decrypted Text = " + decryptedMessage);
            
            Console.ReadLine();
        }
    }
}
