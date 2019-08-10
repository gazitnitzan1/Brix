using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Execise_2b
{
    class Characters
    {
        Dictionary<string, ArrayList> charactersDic;
        public Characters()
        {
            charactersDic = new Dictionary<string, ArrayList>();         
        }

        //Read the file and upload it to the Dictionary, then print the strings to the screen.
        public void ReadFromFile(string input)
        {
            int counter = 0;
            string line;
            // Read the file line by line and insert the strings to the dictionary.
            StreamReader file = new StreamReader("./data.txt");

            while ((line = file.ReadLine()) != null)
            {
                insertStringsToDic(line);
                counter++;
            }
            //print all the match strings
            printAllEquals(input);
            file.Close();
            Console.WriteLine("There were {0} lines.", counter);
            // Suspend the screen.  
            Console.ReadLine();
        }
        //map all the string to key - is sorted string values- all the match strings
        public void insertStringsToDic(string s)
        {
            //sort the string from the file
            char[] characters = s.ToArray();
            Array.Sort(characters);
            string sortedString = new string(characters);

            //if the Dictionary contains the string add it to the Arraylist values
            if(charactersDic.ContainsKey(sortedString))
                charactersDic[sortedString].Add(s);
            else
            {
                //else add the string to new ArrayList in the values
                ArrayList stringsEqualsList = new ArrayList();
                stringsEqualsList.Add(s);
                charactersDic.Add(sortedString, stringsEqualsList);
            }
        }
        //in o(1) we can take the input and print it to the string because we have the dictionary with the sorted string in the key
        public void printAllEquals(string input)
        {
            //sort the string
            char[] characters = input.ToArray();
            Array.Sort(characters);
            string sortedString = new string(characters);

            //if the dictionary contains the sortedString print all the ArrayList in the value of the sorted string in the key of the Dictionary
            if (charactersDic.ContainsKey(sortedString))
            {
                for(int i=0; i<charactersDic[sortedString].Count; i++)
                {
                    Console.WriteLine(charactersDic[sortedString][i]);
                }
            }
            else
            {
                Console.WriteLine("There is no match!");
            }
        }
    }
}
