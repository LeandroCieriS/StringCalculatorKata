using System;
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
        public void ReturnAdditionWhenInputIsAnyNumbers()
        {
            Assert.AreEqual(6, stringCalculator.Add("1,2,3"));
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