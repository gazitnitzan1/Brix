using System;
using System.IO;

namespace Execise_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter 5 character string: ");
            string input = Console.ReadLine();
            if (input.Length == 5)
                ReadFromFile(input.ToUpper());
            else
                Console.Write("You must enter 5 character string, try again!");
        }

        public static void ReadFromFile(string s1)
        {
            int counter = 0;
            string line;
            // Read the file and display it line by line.
            StreamReader file = new StreamReader("./data.txt");

            while ((line = file.ReadLine()) != null)
            {
                bool isPermutation = Compare2Strings(s1, line);
                counter++;
                if (isPermutation)
                {
                    Console.WriteLine(line);
                }
            }
            file.Close();
            Console.WriteLine("There were {0} lines.", counter);
            // Suspend the screen.  
            Console.ReadLine();
        }

        public static bool Compare2Strings(string s1, string s2)
        {
            int[] characters = new int[128];
            char[] stringsArray = s1.ToCharArray();
            foreach(char c in stringsArray)
            {
                characters[c]++;
            }
            for(int i=0; i< s2.Length; i++)
            {
                int c = (int)s2[i];
                characters[c]--;
                if(characters[c] < 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
