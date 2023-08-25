using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TestFlightKata.DataClass;

namespace TestFlightKata
{
    public class DataConversionMethods
    {
        public static int getCharValue(char c)
        {
            foreach (KeyValuePair<int, char> k in charDict)
            {
                if (k.Value == c)
                    return k.Key;
            }
            return -1;
        }

        public static List<string> Stage1Conv(string seed)
        {
            int charCounter = 0;
            List<string> list = new List<string>();
            for (int i = 0; i < Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(seed.Length) / 16)); i++)
            {
                string temp = String.Empty;

                for (int j = 0; j < 16; j++)
                {
                    if (charCounter < seed.Length)
                    {
                        temp += seed[charCounter];
                        charCounter++;
                    }
                }
                list.Add(temp);
            }

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

        public static List<string> Stage2AConv (List<string> list)
        {
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
            foreach(KeyValuePair<int, char> pair in charDict)
            {
                if (pair.Value == c)
                {
                    charNumber = pair.Key + 13;
                    if (charNumber > 26)
                    {
                        charNumber -= 26;
                    }
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
            List<int> vowelKeyList = new List<int>
            {
                1,5,9,15,21,25
            };

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
                    if (CheckIfConsonant(temp[j]))
                    {
                        temp[j] = ConvertConsonant(temp[j]);
                    }
                }
                string convertedString = new string(temp);
                list[i] = convertedString;
            }
            return list;
        }
    }
}
