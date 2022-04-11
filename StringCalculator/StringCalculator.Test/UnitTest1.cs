using System;
using System.Linq;
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
        [TestCase(1, "1")]
        [TestCase(2, "2")]
        [TestCase(3, "3")]
        public void ReturnNumberWhenInputIsSingleNumber(int expected, string input)
        {

            Assert.AreEqual(expected, stringCalculator.Add(input));
        }

        [Test]
        [TestCase(3, "1,2")]
        [TestCase(5, "2,3")]
        [TestCase(7, "3,4")]
        public void ReturnAdditionOfTwoNumbers(int expected, string input)
        {

            Assert.AreEqual(expected, stringCalculator.Add(input));
        }

    }

    public class StringCalculator
    {
        public int Add(string input)
        {
            if (input == "")
                return 0;
            var splitInput = input.Split(",");
            return splitInput.Select(int.Parse).Sum();
        }
    }
}