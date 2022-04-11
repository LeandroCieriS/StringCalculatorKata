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

            Assert.Equals(0, stringCalculator.Add(""));
        }

      
    }

    public class StringCalculator
    {
        public int Add(string empty)
        {
            throw new NotImplementedException();
        }
    }
}