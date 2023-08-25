using TestFlightKata;

using static TestFlightKata.DataConversionMethods;

List<string> test = Stage1Conv("ABCDEFGHIJKLMNOPQRSTUVWXYZ");

foreach (string s in test)
{
    Console.WriteLine(s);
}
