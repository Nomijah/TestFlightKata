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

            // When converted according to instructions.
            // "Discarding all whitespace, divide the seed up into groups of 16
            // characters. If the last group is not of 16 characters,
            // append the alphabet until it is."
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
            // "Reverse the order of characters in the group"
            List<string> actual = Stage2AConv(testList);

            // Expect result to be the strings reversed
            List<string> expected = new List<string>
            {
                "PONMLKJIHGFEDCBA", "FEDCBAZYXWVUTSRQ"
            };
            Assert.Equal(actual, expected);
        }

        [Theory]
        [InlineData('P', 'C')]
        [InlineData('L', 'Y')]
        [InlineData('H', 'U')]
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

            // When converting according to instructions.
            // "Replace every consonant with the character that comes 13
            // positions after alphabetically, wrapping around to the start of the alphabet."
            List<string> actual = Stage2BConv(testList);

            // Expect the correct result
            List<string> expected = new List<string>
            {
                "COAZYXWIUTSEQPOA", "SEQPOAMYKJIUGFED"
            };
            Assert.Equal(actual, expected);
        }

        [Fact]
        public void Stage2CConv_test()
        {
            // Given a list of strings
            List<string> testList = new List<string>
            {
                "COAZYXWIUTSEQPOA", "SEQPOAMYKJIUGFED"
            };

            // When converted according to instructions.
            // "Iteratively from the second character, swap every vowel with
            // the character in the position before it."
            List<string> actual = Stage2CConv(testList);

            // Expect correct conversion
            List<string> expected = new List<string>
            {
                "OACYZXIUWTESQOAP", "ESQOAPYMKIUJGEFD"
            };
            Assert.Equal(actual, expected);
        }

        [Fact]
        public void Stage2DConv_test()
        {
            // Given a list of strings
            List<string> testList = new List<string>
            {
                "OACYZXIUWTESQOAP", "ESQOAPYMKIUJGEFD"
            };

            // When converted according to instructions.
            // "Replace each character with its numerical position in the alphabet."
            List<int[]> actual = Stage2DConv(testList);

            // Expect correct result
            List<int[]> expected = new List<int[]>
            {
                new int[]{15, 1, 3, 25, 26, 24, 9, 21, 23, 20, 5, 19, 17, 15, 1, 16},
                new int[]{5, 19, 17, 15, 1, 16, 25, 13, 11, 9, 21, 10, 7, 5, 6, 4}

            };
            Assert.Equal(actual, expected);
        }

        [Fact]
        public void Stage3AConv_test()
        {
            // Given a list of integer arrays
            List<int[]> testList = new List<int[]>
            {
                new int[]{15, 1, 3, 25, 26, 24, 9, 21, 23, 20, 5, 19, 17, 15, 1, 16},
                new int[]{5, 19, 17, 15, 1, 16, 25, 13, 11, 9, 21, 10, 7, 5, 6, 4}

            };

            // When adding them together according to instructions.
            // "Position by position, add all numbers at that position from all
            // the groups together."
            int[] actual = Stage3AConv(testList);

            // Expect correct result
            int[] expected = new int[]
            {
                20, 20, 20, 40, 27, 40, 34, 34, 34, 29, 26, 29, 24, 20, 7, 20
            };
            Assert.Equal(actual, expected);
        }

        [Theory]
        [InlineData(5,'E')]
        [InlineData(27,'A')]
        [InlineData(112,'H')]
        public void GetCharByKey_test(int a, char b) 
        {
            // Given an integer
            int testInt = a;

            // When converted to a character
            char actual = GetCharByKey(testInt);

            // Expect correct character to be returned
            char expected = b;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Stage3BConv_test()
        {
            // Given an array of integers
            int[] testArray = new int[]
            {
                20, 20, 20, 40, 27, 40, 34, 34, 34, 29, 26, 29, 24, 20, 7, 20
            };

            // When converted to a string according to instructions.
            // "Replace each number by the character at that position in
            // the alphabet, wrapping around if necessary."
            string actual = Stage3BConv(testArray);

            // Expect correct result
            string expected = "TTTNANHHHCZCXTGT";
            Assert.Equal(expected, actual);
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