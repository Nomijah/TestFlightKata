using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using TestFlightKata.Data;

namespace TestFlightKata
{
    public class StarCalculations
    {
        public static double CalculateDistance(StarSystem s1,  StarSystem s2)
        {
            return Math.Sqrt(
                Math.Pow((s1.A - s2.A), 2) +
                Math.Pow((s1.B - s2.B), 2) +
                Math.Pow((s1.C - s2.C), 2) +
                Math.Pow((s1.D - s2.D), 2));
        }

        public static List<StarSystem> NearestStar(StarSystem s1, List<StarSystem> starList) 
        {
            double shortestDistance = 200000;
            string currentNearest = String.Empty;
            foreach (StarSystem star in starList) 
            {
                if (!star.Visited)
                {
                    double distance = CalculateDistance(s1, star);
                    if (distance < shortestDistance)
                    {
                        shortestDistance = distance;
                        currentNearest = star.Name;
                    }
                }
            }
            // Get number of last visited star and add 1
            int counter = starList.Where(s => s.Visited == true).Count() + 1;
            // Edit properties of nearest star
            int indexNr = starList.FindIndex(s => s.Name == currentNearest);
            starList[indexNr].OrderVisited = counter;
            starList[indexNr].Visited = true;
            return starList;
        }

        public static StarSystem GetNextStart(List<StarSystem> starList) 
        {
            return starList.MaxBy(s => s.OrderVisited);
        }

        public static List<StarSystem> TravelToFirstStar(List<StarSystem> starList)
        {
            var sun = new StarSystem() { Name = "Sol", A = 0, B = 0, C = 0, D = 0 };
            starList = StarCalculations.NearestStar(sun, starList);
            return starList;
        }

        public static List<StarSystem> TravelToNextStar(List<StarSystem> starList)
        {
            var nextStar = StarCalculations.GetNextStart(starList);
            starList = StarCalculations.NearestStar(nextStar, starList);
            return starList;
        }

        public static List<StarSystem> GetStarOrder(List<StarSystem> starList)
        {
            for (int i = 0; i < starList.Count; i++)
            {
                if (i == 0)
                {
                    starList = TravelToFirstStar(starList);
                }
                else
                {
                    starList = TravelToNextStar(starList);
                }
            }
            return starList;
        }

        public static List<StarSystem> SortList(List<StarSystem> starList)
        {
            return starList.OrderBy(x => x.OrderVisited).ToList();
        }

        public static string ConvertStarnamesToString(List<StarSystem> starList)
        {
            starList = StarCalculations.GetStarOrder(starList);
            starList = StarCalculations.SortList(starList);
            string temp = "SOL";
            foreach (StarSystem starSystem in starList)
            {
                temp += starSystem.Name;
            }
            temp += "SOL";
            return temp;
        }
    }
}
