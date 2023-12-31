﻿using TestFlightKata;
using System.IO;

using static TestFlightKata.DataConversionMethods;
using static TestFlightKata.Stage3Methods;
using TestFlightKata.Data;

//// Part 1 solution
//StreamReader sr = new StreamReader("C:\\Users\\pette\\source\\repos\\Test-Flight-Kata\\TestFlightKata\\TestFlightKata\\SeedData\\SeedData1.txt");
//string seedData1 = StringCleanup(sr.ReadToEnd());
//Console.WriteLine(CodeGenerator1(seedData1));

//// Part 2 solution
//var stars = StarSystem.ReadStarFile();
//string seedData2 = StringCleanup(StarCalculations.ConvertStarnamesToString(stars));
//Console.WriteLine(CodeGenerator1(seedData2));

// Part 3 solution
StreamReader sr = new StreamReader("C:\\Users\\pette\\source\\repos\\Test-Flight-Kata\\TestFlightKata\\TestFlightKata\\SeedData\\SeedData3.txt");
string seedData3 = StringCleanup(sr.ReadToEnd());
Console.WriteLine(ConvertAllStringsInSeedList(seedData3));
