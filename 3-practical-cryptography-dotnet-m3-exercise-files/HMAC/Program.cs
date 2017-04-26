using System;
using System.Text;

namespace CryptographyInDotNet
{
    class Program
    {
        static void Main()
        {
            const string originalMessage = "Original Message to hash";
            const string originalMessage2 = "Original xessage to hash";

            Console.WriteLine("HMAC Demonstration in .NET");
            Console.WriteLine("--------------------------");
            Console.WriteLine();

            var key = Hmac.GenerateKey();

            var hmacMd5Message = Hmac.ComputeHmacmd5(Encoding.UTF8.GetBytes(originalMessage), key);
            var hmacMd5Message2 = Hmac.ComputeHmacmd5(Encoding.UTF8.GetBytes(originalMessage2), key);

            var hmacSha1Message = Hmac.ComputeHmacsha1(Encoding.UTF8.GetBytes(originalMessage), key);
            var hmacSha1Message2 = Hmac.ComputeHmacsha1(Encoding.UTF8.GetBytes(originalMessage2), key);

            var hmacSha256Message = Hmac.ComputeHmacsha256(Encoding.UTF8.GetBytes(originalMessage), key);
            var hmacSha256Message2 = Hmac.ComputeHmacsha256(Encoding.UTF8.GetBytes(originalMessage2), key);

            var hmacSha512Message = Hmac.ComputeHmacsha512(Encoding.UTF8.GetBytes(originalMessage), key);
            var hmacSha512Message2 = Hmac.ComputeHmacsha512(Encoding.UTF8.GetBytes(originalMessage2), key);

            Console.WriteLine();
            Console.WriteLine("MD5 HMAC");
            Console.WriteLine();
            Console.WriteLine("Message 1 hash = " + Convert.ToBase64String(hmacMd5Message));
            Console.WriteLine("Message 2 hash = " + Convert.ToBase64String(hmacMd5Message2));

            Console.WriteLine();
            Console.WriteLine("SHA 1 HMAC");
            Console.WriteLine();
            Console.WriteLine("Message 1 hash = " + Convert.ToBase64String(hmacSha1Message));
            Console.WriteLine("Message 2 hash = " + Convert.ToBase64String(hmacSha1Message2));            

            Console.WriteLine();
            Console.WriteLine("SHA 256 HMAC");
            Console.WriteLine();
            Console.WriteLine("Message 1 hash = " + Convert.ToBase64String(hmacSha256Message));
            Console.WriteLine("Message 2 hash = " + Convert.ToBase64String(hmacSha256Message2));            

            Console.WriteLine();
            Console.WriteLine("SHA 512 HMAC");
            Console.WriteLine();
            Console.WriteLine("Message 1 hash = " + Convert.ToBase64String(hmacSha512Message));
            Console.WriteLine("Message 2 hash = " + Convert.ToBase64String(hmacSha512Message2));
            Console.WriteLine();

            
            Console.ReadLine();
        }
    }
}
