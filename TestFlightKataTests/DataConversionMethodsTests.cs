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

        [Theory]
        [InlineData('P','C')]
        [InlineData('L','Y')]
        [InlineData('H','U')]
        public static void ConvertConsonant_test(char a, char b)
        {
            // Given a character
            char one = a;
            char two = b;

            // When converting to a character 13 steps after in the alphabet
            char actual = ConvertConsonant(a);

            // Expect correct conversion
            char expected = two;
            Assert.Equal(actual, expected);
        }

        [Theory]
        [InlineData('A', false)]
        [InlineData('K', true)]
        [InlineData('T', true)]
        public static void CheckIfConsonant_test(char a, bool b)
        {
            // Given a character
            char test = a;

            // When checking whether it is a consonant
            bool actual = CheckIfConsonant(a);

            // Expect result to be correct
            bool expected = b;
            Assert.Equal(actual, expected);

        }

        [Fact]
        public void Stage2BConv_test()
        {
            // Given a list of strings
            List<string> testList = new List<string>
            {
                "PONMLKJIHGFEDCBA", "FEDCBAZYXWVUTSRQ"
            };

            // When converting according to instructions
            List<string> actual = Stage2BConv(testList);

            // Expect the correct result
            List<string> expected = new List<string>
            {
                "COAZYXWIUTSEQPOA", "SEQPOAMYKJIUGFED"
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