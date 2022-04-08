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
    }

    public class StringCalculator
    {

        public int Add(string s)
        {
            
            return 0;
        }
    }
}