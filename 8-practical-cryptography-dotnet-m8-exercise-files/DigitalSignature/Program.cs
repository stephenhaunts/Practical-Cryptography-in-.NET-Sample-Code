using System;
using System.Security.Cryptography;
using System.Text;

namespace CryptographyInDotNet
{
    class Program
    {
        static void Main()
        {                                               
            var document = Encoding.UTF8.GetBytes("Document to Sign");
            byte[] hashedDocument;

            using (var sha256 = SHA256.Create())
            {
                hashedDocument = sha256.ComputeHash(document);
            }

            var digitalSignature = new DigitalSignature();
            digitalSignature.AssignNewKey();

            var signature = digitalSignature.SignData(hashedDocument);
            var verified = digitalSignature.VerifySignature(hashedDocument, signature);
            
            Console.WriteLine("Digital Signature Demonstration in .NET");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine();            
            Console.WriteLine();
            Console.WriteLine("   Original Text = " + 
                Encoding.Default.GetString(document));

            Console.WriteLine();
            Console.WriteLine("   Digital Signature = " + 
                Convert.ToBase64String(signature));

            Console.WriteLine();

            Console.WriteLine(verified
                ? "The digital signature has been correctly verified."
                : "The digital signature has NOT been correctly verified.");

            Console.ReadLine();
        }
    }
}
