using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFlightKata.Data
{
    public class StarSystem
    {
        public string Name { get; set; }
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }
        public double D { get; set; }
        public bool Visited { get; set; }
        public int OrderVisited { get; set; }

        public static List<StarSystem> ReadStarFile()
        {
            List<StarSystem> stars = new List<StarSystem>();
            StreamReader sr = new StreamReader("C:\\Users\\pette\\source\\repos\\Test-Flight-Kata\\TestFlightKata\\TestFlightKata\\SeedData\\SeedData2.txt");
            // Read seed data and split into rows
            string[] rows = sr.ReadToEnd().Split('\n');
            List<Tuple<string, string>> rowTuples = new List<Tuple<string, string>>();
            // Split each row into two strings, one with the name and the 
            // other with the coordinates.
            foreach (string row in rows)
            {
                string[] tempArray = row.Split('(');
                Tuple<string, string> temp = new Tuple<string, string>(
                    tempArray[0],
                    tempArray[1].Remove(tempArray[1].Length - 2)
                );
                rowTuples.Add(temp);
            }
            // Create new star systems with the data
            foreach (Tuple<string,string> tuple in rowTuples)
            {
                // Split the coordinates to separate strings
                string[] temp = tuple.Item2.Split(",");
                stars.Add(new StarSystem()
                {
                    Name = tuple.Item1,
                    A = Convert.ToDouble(temp[0].Replace('.', ',')),
                    B = Convert.ToDouble(temp[1].Replace('.', ',')),
                    C = Convert.ToDouble(temp[2].Replace('.', ',')),
                    D = Convert.ToDouble(temp[3].Replace('.', ',')),
                    Visited = false
                });
            }
            return stars;
        }
    }
}
