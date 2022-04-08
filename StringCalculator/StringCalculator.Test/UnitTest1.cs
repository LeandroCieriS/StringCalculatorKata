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
        public void Return1WhenInputIsOne()
        {
            var stringCalculator = new StringCalculator();

            Assert.AreEqual(1, stringCalculator.Add("1"));
        }

        [Test]
        public void Return2WhenInputIsTwo()
        {
            var stringCalculator = new StringCalculator();

            Assert.AreEqual(2, stringCalculator.Add("2"));
        }
    }

    public class StringCalculator
    {

        public int Add(string input)
        {
            if (input.Equals(""))
                return 0;
            return 1;
        }
    }
}