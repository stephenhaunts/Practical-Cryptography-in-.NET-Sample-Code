using System;

namespace CryptographyInDotNet
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Random Number Demonstration in .NET");
            Console.WriteLine("---------------------------------");
            Console.WriteLine();

            for (var i = 0; i < 10; i++)
            {
                Console.WriteLine("Random Number " + i + " : " 
                    + Convert.ToBase64String(Random.GenerateRandomNumber(32)));
            }
            
            Console.ReadLine();
        }
    }
}
