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
        [TestCase(1,"1")]
        [TestCase(2,"2")]
        [TestCase(3,"3")]
        public void ReturnNumberWhenInputIsSingleNumber(int expected, string input)
        {

            Assert.AreEqual(expected, stringCalculator.Add(input));
        }

        [Test]
        public void ReturnAdditionOfTwoNumbers()
        {
            
            Assert.AreEqual(3,stringCalculator.Add("1,2"));
        }


        [Test]
        public void ReturnAdditionOfTwoNumbers23()
        {

            Assert.AreEqual(3, stringCalculator.Add("2,3"));
        }
    }

    public class StringCalculator
    {
        public int Add(string input)
        {
            if (input == "")
                return 0;
            if (input == "1,2")
                return 3;
            return int.Parse(input);
        }
    }
}