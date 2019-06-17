using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using SuperHeroes.Implementation;
using SuperHeroesUnitTests.HelperMethods;

namespace SuperHeroesUnitTests
{
    public class StringFileReaderUnitTests
    {
        [Test]
        public void StringFileReaderReadsFromFileSuccessfully()
        {
            //Arrange
            var configuration = InitConfiguration.GetSettings();

            //Act
            var stringReader = new StringFileReader(configuration);
            var fileContents = stringReader.ReadFromFile();

            //Assert
            Assert.NotZero(fileContents.Count);
        }

        [Test]
        public void StringFileReaderDoesNotReadEmptyLines()
        {
            //Arrange
            var configuration = InitConfiguration.GetSettings();

            //Act
            var stringReader = new StringFileReader(configuration);
            var fileContents = stringReader.ReadFromFile();

            //Assert
            Assert.AreEqual(18,fileContents.Count);
        }
    }
}