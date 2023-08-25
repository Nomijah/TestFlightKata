using TestFlightKata;
using System.IO;

using static TestFlightKata.DataConversionMethods;

StreamReader sr = new StreamReader("C:\\Users\\pette\\source\\repos\\Test-Flight-Kata\\TestFlightKata\\TestFlightKata\\SeedData\\SeedData1.txt");
string seedData1 = StringCleanup(sr.ReadToEnd());
Console.WriteLine(CodeGenerator1(seedData1));