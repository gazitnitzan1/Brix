using System;
using System.IO;
using System.Linq;

namespace Execise_2b
{
    class Program
    {
        static void Main(string[] args)
        {
            Characters chars = new Characters();
            Console.Write("Enter 5 character string: ");
            string input = Console.ReadLine();
            if (input.Length == 5)
                chars.ReadFromFile(input);
            else
                Console.Write("You must enter 5 character string, try again!");
        }
       
    }
}
