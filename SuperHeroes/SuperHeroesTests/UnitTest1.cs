using NUnit.Framework;
using SuperHeroes.Implementation;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            var containsDRule = new ContainsDRule();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}