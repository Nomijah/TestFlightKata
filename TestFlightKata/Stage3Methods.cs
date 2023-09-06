using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using static TestFlightKata.DataConversionMethods;

namespace TestFlightKata
{
    public class Stage3Methods
    {
        public static string Permutation1(string seed)
        {
            // Reverse order of chars in string.
            char[] temp = seed.ToCharArray();
            Array.Reverse(temp);
            string result = new string(temp);

            return result;
        }

        public static string Permutation2(string seed)
        {
            char[] temp = seed.ToCharArray();
            for (int j = 0; j < temp.Length; j++)
            {
                // If the char is a consonant, convert it.
                if (CheckIfConsonant(temp[j]))
                {
                    temp[j] = ConvertConsonant(temp[j]);
                }
            }
            string result = new string(temp);

            return result;
        }

        public static string Permutation3(string seed)
        {
            char[] temp = seed.ToCharArray();
            // Start at second character
            for (int j = 1; j < temp.Length; j++)
            {
                // If it's a vowel
                if (!CheckIfConsonant(temp[j]))
                {
                    // Switch places with the character before
                    char tempStorage = temp[j - 1];
                    temp[j - 1] = temp[j];
                    temp[j] = tempStorage;
                }
            }
            // Save the converted string
            string result = new string(temp);
            return result;
        }

        public static string Permutation4(string seed)
        {
            char[] temp = seed.ToCharArray();
            for (int i = 0; i < temp.Length; i += 2)
            {
                // Sum up value of current and next char.
                int combinedValue = GetCharValue(temp[i]) + GetCharValue(temp[i + 1]);
                // Replace chars according to new value
                temp[i] = GetCharByKey(combinedValue);
                temp[i + 1] = GetCharByKey(combinedValue);
            }
            string result = new string(temp);
            return result;
        }

        public static string Permutation5(string seed)
        {
            char[] temp = seed.ToCharArray();
            // Loop through every second character starting from the second.
            for (int i = 1; i < temp.Length; i += 2)
            {
                int newValue = GetCharValue(temp[i]) - 13;
                // Check if value is negative, if true then wrap around.
                if (newValue < 1)
                {
                    newValue += 26;
                }
                temp[i] = GetCharByKey(newValue);
            }
            string result = new string(temp);
            return result;
        }

        public static string Permutation6(string seed)
        {
            // Switch places for first and second half of string
            string temp1 = seed[..(seed.Length/2)];
            string temp2 = seed[(seed.Length / 2)..];
            return temp2 + temp1;
        }

        public static string RunPermutationById(string seed, int id)
        {
            switch (id)
            {
                case 1: return Permutation1(seed);
                case 2: return Permutation2(seed);
                case 3: return Permutation3(seed);
                case 4: return Permutation4(seed);
                case 5: return Permutation5(seed);
                case 6: return Permutation6(seed);
                default: return seed;
            }
        }

        public static List<string> SeedSplitter(string seed)
        {
            // First part with instructions length will vary depending on the 
            // amount of groups following. Separate it before grouping the rest.
            int firstPartCount = 
                Convert.ToInt32(Math.Ceiling((Convert.ToDecimal(seed.Length) - 
                (Convert.ToDecimal(seed.Length) / 16)) / 16));
            string instructions = seed[..firstPartCount];
            string remaining = seed[firstPartCount..];

            // Group the string without the first part included.
            List<string> groups = Stage1Conv(remaining);

            // Add all strings to a new list.
            List<string> result = new List<string>(){instructions};
            foreach (var group in groups)
            {
                result.Add(group);
            }
            return result;
        }

        public static int[] GetIntsFromChar(char input)
        {
            switch (input)
            {
                case 'A': return new int[] { 1, 2, 3 };
                case 'B': return new int[] { 4, 5, 6 };
                case 'C': return new int[] { 2, 4, 3 };
                case 'D': return new int[] { 6, 1, 4 };
                case 'E': return new int[] { 3, 5, 1 };
                case 'F': return new int[] { 5, 3, 2 };
                default: return new int[] { 0 };
            }
        }

        public static List<int[]> GetInstructions(string seed)
        {
            // Convert the first seed with instructions to an array of ints.
            List<int[]> instrArr = new List<int[]>();
            foreach (char c in seed)
            {
                instrArr.Add(GetIntsFromChar(c));
            }
            return instrArr;
        }

        public static string ConvertStringByIntArray(string seed, int[] instr)
        {
            // Convert the string according to the instruction values in the array.
            foreach (int i in instr)
            {
                seed = RunPermutationById(seed, i);
            }
            return seed;
        }

        public static string ConvertAllStringsInSeedList(string seed)
        {
            // Split the seed in to groups
            List<string> seedList = SeedSplitter(seed);

            // Convert first group to array with conversion instructions
            List<int[]> convInstr = GetInstructions(seedList[0]);

            // Remove the first group (with instructions) from the list
            seedList.RemoveAt(0);
            
            // Convert each group of strings in the list
            for (int i = 0; i < convInstr.Count; i++)
            {
                seedList[i] = ConvertStringByIntArray(seedList[i], convInstr[i]);
            }

            // Do the last steps of conversion from V1.0
            return Stage3BConv(Stage3AConv(Stage2DConv(seedList)));
        }
    }
}
