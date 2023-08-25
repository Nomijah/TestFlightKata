using TestFlightKata;

using static TestFlightKata.DataConversionMethods;

List<string> test = Stage1Conv("ABCDEFGHIJKLMNOPQ");

foreach (string s in test)
{
    Console.WriteLine(s);
}
