using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using NUnit.Framework;

namespace StringCalculator.Test
{
    public class StringCalculatorShould
    {
        private StringCalculator stringCalculator;
        [SetUp]
        public void Setup()
        {
            stringCalculator = new StringCalculator();
        }

        [Test]
        public void Return0WhenEmptyString()
        {

            Assert.AreEqual(0, stringCalculator.Add(""));
        }

        [Test]
        [TestCase(1,"1")]
        [TestCase(2,"2")]
        [TestCase(3,"3")]
        public void ReturnNumberWhenInputIsThatNumber(int expected, string input)
        {

            Assert.AreEqual(expected, stringCalculator.Add(input));
        }

        [Test]
        [TestCase(3, "1,2")]
        [TestCase(4, "2,2")]
        [TestCase(3, "2,1")]
        public void ReturnAdditionWhenInputIsTwoNumbers(int expected, string input)
        {
            Assert.AreEqual(expected, stringCalculator.Add(input));
        }

        [Test]
        [TestCase(6, "1,2,3")]
        [TestCase(9, "2,2,1,4")]
        [TestCase(12, "2,1,6,1,2")]
        public void ReturnAdditionWhenInputIsAnyNumbers(int expected, string input)
        {

            Assert.AreEqual(expected, stringCalculator.Add(input));
        }

        [Test]
        public void UseNewLineAsSeparator()
        {

            Assert.AreEqual(6, stringCalculator.Add("1,2\n3"));
        }

        [Test]
        public void LetUserChangeSeparator()
        {

            Assert.AreEqual(6, stringCalculator.Add("//[;]\n1;2;3"));
        }

        [Test]
        public void NotAllowNegativeNumbers()
        {

            Assert.Throws<InvalidOperationException>(() => stringCalculator.Add("1,2,-3"));
        }

        [Test]
        public void IgnoreNumbersBiggerThan1000()
        {

            Assert.AreEqual(1004, stringCalculator.Add("//[;]\n1;2000;3;1001;1000"));
        }

        [Test]
        public void AllowMultipleCharactersAsSeparator()
        {

            Assert.AreEqual(1004, stringCalculator.Add("//[***]\n1***2000***3***1001***1000"));
        }

        [Test]
        [TestCase("//[*][%]\n1*2000*3%1001*1000", 1004)]
        [TestCase("//[*][%][-][.]\n1.2000*3%1001-1000", 1004)]
        public void AllowMultipleUniqueSeparators(string input, int expected)
        {

            Assert.AreEqual(expected, stringCalculator.Add(input));
        }
    }

    public class StringCalculator
    {
        public int Add(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return 0;
            var splitInput = SplitInput(input);
            var castInput = splitInput.Select(int.Parse).Where(n => n <= 1000).ToList();
            CheckForNegatives(castInput);
            return castInput.Sum();
        }

        private static string[] SplitInput(string input)
        {
            input = ChangeSeparatorForComma(input);
            var splitInput = input.Split(",");
            return splitInput;
        }

        private static void CheckForNegatives(IEnumerable<int> castInput)
        {
            var negativeNumbers = castInput.Where(n => n < 0).ToList();
            if (negativeNumbers.Any())
                throw new InvalidOperationException($"Negatives not allowed {string.Join(", ", negativeNumbers)}");
        }

        private static string ChangeSeparatorForComma(string input)
        {
            if (input.StartsWith("//"))
            {
                input = input[2..];
                input = ReplaceSeparators(input);
            }

            input = input.Replace("\n", ",");
            return input;
        }

        private static string ReplaceSeparators(string input)
        {
            var separatorLength = input.IndexOf("]") - 1;
            var separator = input.Substring(input.IndexOf("[") + 1, separatorLength);
            input = input.Replace(separator, ",");
            input = DeleteSeparator(input);
            return InputHasMoreSeparators(input) ? ReplaceSeparators(input) : input[1..];
        }

        private static string DeleteSeparator(string input)
        {
            return input[(input.IndexOf("]") + 1)..];
        }

        private static bool InputHasMoreSeparators(string input)
        {
            return input.IndexOf("[") != -1;
        }
    }
}