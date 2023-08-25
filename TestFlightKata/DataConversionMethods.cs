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
            for (int i = 0; i < Convert.ToInt32(Math.Round(Convert.ToDecimal(seed.Length) / 16)); i++)
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
    }
}
