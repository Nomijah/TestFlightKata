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
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Stage2AConv_test()
        {
            // Given a list of strings
            List<string> testList = new List<string>
            {
                "ABCDEFGHIJKLMNOP", "QRSTUVWXYZABCDEF"
            };

            // When converting at first part of second stage
            List<string> actual = Stage2AConv(testList);

            // Expect result to be the strings reversed
            List<string> expected = new List<string>
            {
                "PONMLKJIHGFEDCBA", "FEDCBAZYXWVUTSRQ"
            };
            Assert.Equal(actual, expected);
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