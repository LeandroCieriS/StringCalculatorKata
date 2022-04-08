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
        public void ReturnNumberWhenInputIsCharacter(int expected, string input)
        {

            Assert.AreEqual(expected, stringCalculator.Add(input));
        }

        [Test]

        public void ReturnAdditionWhenInputIs2Numbers()
        {

            Assert.AreEqual(3, stringCalculator.Add("1,2"));
        }
    }

    public class StringCalculator
    {

        public int Add(string input)
        {
            if (input.Equals(""))
                return 0;
            var spplitedInput = input.Split(",");
            var convertedInput = Array.ConvertAll(spplitedInput, s => int.Parse(s));
            return convertedInput.Sum();
        }
    }
}