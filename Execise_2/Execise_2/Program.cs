using System;

namespace Execise_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter 5 character string: ");
            string val = Console.ReadLine();
            if(val.Length==5)
                ReadFromFile(val.ToUpper());
            else
                Console.Write("You must enter 5 charcter string, try again!");
        }

        public static void ReadFromFile(string s1)
        {
            int counter = 0;
            string line;

            // Read the file and display it line by line.  
            System.IO.StreamReader file = new System.IO.StreamReader("./data.txt");

            while ((line = file.ReadLine()) != null)
            {
                bool ans = Compare2Strings(s1, line);
                counter++;

                if (ans)
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
            int[] letters = new int[128];

            char[] s_array = s1.ToCharArray();
            foreach(char c in s_array)
            {
                letters[c]++;
            }

            for(int i=0; i< s2.Length; i++)
            {
                int c = (int)s2[i];
                letters[c]--;
                if(letters[c] <0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
