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

            Assert.AreEqual(6, stringCalculator.Add("//;\n1;2;3"));
        }

        [Test]
        public void NotAllowNegativeNumbers()
        {

            Assert.Throws<InvalidOperationException>(() => stringCalculator.Add("1,2,-3"));
        }

        [Test]
        public void IgnoreNumbersBiggerThan1000()
        {

            Assert.AreEqual(1004, stringCalculator.Add("//;\n1;2000;3;1001;1000"));
        }
    }

    public class StringCalculator
    {
        public int Add(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return 0;
            var splitInput = SplitInput(input);
            var castInput = splitInput.Select(int.Parse);
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
                input = input.Replace(input[2].ToString(), ",");
                input = input[4..];
            }

            input = input.Replace("\n", ",");
            return input;
        }
    }
}