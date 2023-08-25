using static TestFlightKata.DataConversionMethods;

namespace TestFlightKataTests
{
    public class DataConversionMethodsTests
    {
        [Fact]
        public void Stage1Conv_test()
        {
            // Given a string of characters
            string testString = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            // When converted at stage one
            List<string> actual = Stage1Conv(testString);

            // Expect the result to be a list of two strings with set characters
            List<string> expected = new List<string>
            {
                "ABCDEFGHIJKLMNOP", "QRSTUVWXYZABCDEF"
            };
            Assert.Equal(expected[0], actual[0]);
            Assert.Equal(expected[1], actual[1]);
        }

        [Fact]
        public void CodeGenerator1_test()
        {
            // Given a string
            string testString = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            // When converted according to specific rules

            string actual = String.Empty;

            // Expect the conversion to result in TTTNANHHHCZCXTGT
            string expected = "TTTNANHHHCZCXTGT";
            Assert.Equal(expected, actual);

        }
    }
}