using TestFlightKata;

using static TestFlightKata.DataConversionMethods;

List<string> test = Stage1Conv("ABCDEFGHIJKLMNOPQ");
test = Stage2AConv(test);

foreach (string s in test)
{
    Console.WriteLine(s);
}
