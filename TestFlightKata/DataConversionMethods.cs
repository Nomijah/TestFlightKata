using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static TestFlightKata.DataClass;

namespace TestFlightKata
{
    public class DataConversionMethods
    {
        public static string StringCleanup(string s)
        {
            Regex rgx = new Regex("[^A-Z]");
            List<char> temp = s.ToCharArray().ToList();
            for (int i = temp.Count -1; i >= 0; i--)
            {
                if (rgx.IsMatch(temp[i].ToString()))
                {
                    temp.RemoveAt(i);
                }
            }
            string result = String.Empty;
            foreach (char c in temp)
            {
                result += c;
            }
            return result;
        }
        public static int GetCharValue(char c)
        {
            // Loop through dictionary to find the integral value.
            foreach (KeyValuePair<int, char> k in charDict)
            {
                if (k.Value == c)
                    return k.Key;
            }
            return -1;
        }

        public static List<string> Stage1Conv(string seed)
        {
            // Counter to make sure that the loop doesn't throw index out of range exception.
            int charCounter = 0;

            List<string> list = new List<string>();
            // Create the correct amount of strings by dividing the string
            // length by 16 and rounding up to nearest integer.
            for (int i = 0;
                i < Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(seed.Length) / 16)); i++)
            {
                string temp = String.Empty;
                // Add the next 16 chars to string.
                for (int j = 0; j < 16; j++)
                {
                    // Makes sure that for loop stops at end of string.
                    if (charCounter < seed.Length)
                    {
                        temp += seed[charCounter];
                        charCounter++;
                    }
                }
                list.Add(temp);
            }
            // Fill the last string with chars if it doesn't contain 16 chars.
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Length < 16)
                {
                    string temp = list[i];
                    for (int j = 1; j <= 16 - list[i].Length; j++)
                    {
                        temp += charDict[j];
                    }
                    list[i] = temp;
                }
            }
            return list;
        }

        public static List<string> Stage2AConv(List<string> list)
        {
            // Reverse order of chars in string.
            for (int i = 0; i < list.Count; i++)
            {
                char[] temp = list[i].ToCharArray();
                Array.Reverse(temp);
                list[i] = new string(temp);
            }
            return list;
        }

        public static char ConvertConsonant(char c)
        {
            int charNumber = 0;
            char newChar = 'a';
            foreach (KeyValuePair<int, char> pair in charDict)
            {
                if (pair.Value == c)
                {
                    // If char goes beyond alphabet, wrap around.
                    charNumber = (pair.Key + 13)%26;
                    // Fix problem if calculation is zero
                    if (charNumber == 0)
                    {
                        newChar = 'Z';
                    }
                    // Get the new char by the new value.
                    foreach (KeyValuePair<int, char> pair2 in charDict)
                    {
                        if (pair2.Key == charNumber)
                        {
                            newChar = pair2.Value;
                        }
                    }
                }
            }
            return newChar;
        }

        public static bool CheckIfConsonant(char a)
        {
            // Key values of the vowels in the alphabet.
            List<int> vowelKeyList = new List<int>
            {
                1,5,9,15,21,25
            };
            // Check wether submitted character is a vowel.
            foreach (KeyValuePair<int, char> pair in charDict)
            {
                if (pair.Value == a)
                {
                    foreach (int i in vowelKeyList)
                    {
                        if (pair.Key == i)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        public static List<string> Stage2BConv(List<string> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                char[] temp = list[i].ToCharArray();
                for (int j = 0; j < temp.Length; j++)
                {
                    // If the char is a consonant, convert it.
                    if (CheckIfConsonant(temp[j]))
                    {
                        temp[j] = ConvertConsonant(temp[j]);
                    }
                }
                list[i] = new string(temp);
            }
            return list;
        }

        public static List<string> Stage2CConv(List<string> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                char[] temp = list[i].ToCharArray();
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
                list[i] = new string(temp);
            }
            return list;
        }

        public static List<int[]> Stage2DConv(List<string> list)
        {
            List<int[]> intArrList = new List<int[]>();
            foreach (string str in list)
            {
                // Create new array to hold integers.
                int[] temp = new int[str.Length];
                // Save the numerical values of each char in string to the array.
                for (int i = 0; i < str.Length; i++)
                {
                    temp[i] = GetCharValue(str[i]);
                }
                // Add the array to the list.
                intArrList.Add(temp);
            }
            return intArrList;
        }

        public static int[] Stage3AConv(List<int[]> list)
        {
            int[] totalArray = new int[list[0].Length];
            foreach (int[] tempArray in list)
            {
                // Add numbers from each postion in every array to same position
                // at new array.
                for (int i = 0; i < list[0].Length; i++)
                {
                    totalArray[i] += tempArray[i];
                }
            }
            return totalArray;
        }

        public static char GetCharByKey(int a)
        {
            // Loop through dictionary to find the integral value.
            foreach (KeyValuePair<int, char> k in charDict)
            {
                // Make sure that the key value is wrapped around if out of range.
                if (k.Key == a%26)
                    return k.Value;
                // Fix for above calculation not working for the letter Z.
                else if (a%26 == 0)
                {
                    return 'Z';
                }
            }
            return 'a';
        }

        public static string Stage3BConv(int[] intArray)
        {
            string result = String.Empty;
            foreach (int i in intArray)
            {
                result += GetCharByKey(i);
            }
            return result;
        }

        public static string CodeGenerator1 (string s)
        {
            // Gotta love this nesting of methods!!!
            return Stage3BConv(Stage3AConv(Stage2DConv(Stage2CConv(Stage2BConv(Stage2AConv(Stage1Conv(s)))))));
        }
    }
}
