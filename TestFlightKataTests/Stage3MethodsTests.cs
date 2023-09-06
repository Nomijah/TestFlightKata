using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TestFlightKata.Stage3Methods;


namespace TestFlightKataTests
{
    public class Stage3MethodsTests
    {
        [Fact]
        public void Permutation1_test()
        {
            // Given a string
            string testString = "ABCDEFGHIJKLMNOP";

            // When permutating according to first instruction
            // "Reverse the order of characters in the group"
            string actual = Permutation1(testString);

            // Expect result to be the string reversed
            string expected = "PONMLKJIHGFEDCBA";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Permutation2_test()
        {
            // Given a string
            string testString = "PONMLKJIHGFEDCBA";

            // When converting according to instructions.
            // "Replace every consonant with the character that comes 13
            // positions after alphabetically, wrapping around to the start of the alphabet."
            string actual = Permutation2(testString);

            // Expect the correct result
            string expected = "COAZYXWIUTSEQPOA";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Permutation3_test()
        {
            // Given a string
            string testString = "COAZYXWIUTSEQPOA";

            // When converted according to instructions.
            // "Iteratively from the second character, swap every vowel with
            // the character in the position before it."
            string actual = Permutation3(testString);

            // Expect correct conversion
            string expected = "OACYZXIUWTESQOAP";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Permutation4_test()
        {
            // Given a string
            string testString = "ABCDEFST";

            // When converted according to instructions.
            // "For each character pair (1 and 2, 3 and 4, etc.) add together
            // their positions in the alphabet and replace both with the
            // character corresponding to the new position, wrapping around if necessary."
            string actual = Permutation4(testString);

            // Except correct conversion
            string expected = "CCGGKKMM";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Permutation5_test()
        {
            // Given a string
            string testString = "ABCDEFGH";

            // When converted according to instructions.
            // "Starting with the second character, replace every second
            // character with the character that comes 13 positions before
            // alphabetically, wrapping around to the back of the alphabet if necessary."
            string actual = Permutation5(testString);

            // Except correct conversion
            string expected = "AOCQESGU";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Permutation6_test()
        {
            // Given a string
            string testString = "ABCDEFGHIJKLMNOP";

            // When converted according to instructions.
            // "Swap the 8 first characters with the 8 last characters of the group."
            string actual = Permutation6(testString);

            // Except correct conversion
            string expected = "IJKLMNOPABCDEFGH";
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("ABCDEFGHIJKLMNOP", "PONMLKJIHGFEDCBA", 1)]
        [InlineData("PONMLKJIHGFEDCBA", "COAZYXWIUTSEQPOA", 2)]
        [InlineData("COAZYXWIUTSEQPOA", "OACYZXIUWTESQOAP", 3)]
        [InlineData("ABCDEFST", "CCGGKKMM", 4)]
        [InlineData("ABCDEFGH", "AOCQESGU", 5)]
        [InlineData("ABCDEFGHIJKLMNOP", "IJKLMNOPABCDEFGH", 6)]
        public void RunPermutationById_test(string seed, string expected, int id)
        {
            // Given a string and a key value
            string testString = seed;
            int testId = id;

            // When sending values to method
            string actual = RunPermutationById(testString, testId);

            // Expect correct converted string to be returned
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SeedSplitter_test()
        {
            // Given a string
            string testString = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            // When broken down into a list of strings where the first contains
            // instructions with letters from A-F and all others contain 16 chars
            // of seed data.
            List<string> actual = SeedSplitter(testString);

            // Expect correct splitting of string
            List<string> expected = new List<string>()
            {
                "AB", "CDEFGHIJKLMNOPQR", "STUVWXYZABCDEFGH"
            };
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData('A', new int[] {1,2,3})]
        [InlineData('B', new int[] {4,5,6})]
        [InlineData('C', new int[] {2,4,3})]
        [InlineData('D', new int[] {6,1,4})]
        [InlineData('E', new int[] {3,5,1})]
        [InlineData('F', new int[] {5,3,2})]
        public void GetIntsFromChar_test(char seed, int[] expected)
        {
            // Given a character
            char testChar = seed;

            // When converted to an array of ints according to instructions
            int[] actual = GetIntsFromChar(testChar);

            // Expect correct result returned
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetInstructions_test()
        {
            // Given a string
            string testString = "ABCDEF";

            // When converted to a list of int-arrays
            List<int[]> actual = GetInstructions(testString);

            // Expect correct result returned
            List<int[]> expected = new List<int[]>()
            {
                new int[]{1,2,3 },
                new int[]{4,5,6 },
                new int[]{2,4,3 },
                new int[]{6,1,4 },
                new int[]{3,5,1 },
                new int[]{5,3,2 }
            };
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("ABCDEFGHIJKLMNOP", "OACYZXIUWTESQOAP", new int[] {1,2,3})]
        public void ConvertStringByIntArray_test(string seed, string expected, int[] instr)
        {
            // Given a string and an int
            string testString = seed;
            int[] testInt = instr;

            // When sent to method for conversion
            string actual = ConvertStringByIntArray(testString, testInt);

            // Expect correct result returned
            Assert.Equal(expected,actual);
        }

        [Fact]
        public void ConvertAllStringsInSeedList_test()
        {
            // Given a string
            string testString = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            // When converting according to TPA reduction algorithm V1.2
            string actual = ConvertAllStringsInSeedList(testString);

            // Expect a string with 16 characters converted correctly
            string expected = "HTVUNWOZVUNXZAPB";
            Assert.Equal(expected, actual);
        }
    }
}
