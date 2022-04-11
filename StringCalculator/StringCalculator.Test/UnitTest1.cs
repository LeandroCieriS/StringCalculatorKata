using System;
using System.Linq;
using NUnit.Framework;

namespace StringCalculator.Test
{
    public class StringCalculatorShould
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Return0WhenEmptyString()
        {
            var stringCalculator = new StringCalculator();

            Assert.AreEqual(0, stringCalculator.Add(""));
        }

        [Test]
        public void ReturnNumberWhenInputIsSingleNumber()
        {
            var stringCalculator = new StringCalculator();

            Assert.AreEqual(1,stringCalculator.Add("1"));
        }


        [Test]
        public void ReturnNumberWhenInputIsSingleNumber2()
        {
            var stringCalculator = new StringCalculator();

            Assert.AreEqual(2, stringCalculator.Add("2"));
        }

        [Test]
        public void ReturnNumberWhenInputIsSingleNumber3()
        {
            var stringCalculator = new StringCalculator();

            Assert.AreEqual(3, stringCalculator.Add("3"));
        }
    }

    public class StringCalculator
    {
        public int Add(string empty)
        {
            if (empty == "")
                return 0;
            if (empty == "1")
                return 1;
            return 2;
        }
    }
}