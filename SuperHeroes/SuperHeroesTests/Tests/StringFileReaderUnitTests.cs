using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using SuperHeroes.Implementation;
using SuperHeroesUnitTests.HelperMethods;

namespace SuperHeroesUnitTests
{
    public class StringFileReaderUnitTests
    {
        public Mock<ILogger<StringFileReader>> getMockLogger()
        {
            return MockLogger.GetLogger<StringFileReader>();
        }

        [Test]
        public void StringFileReaderReadsFromFileSuccessfully()
        {
            //Arrange
            var configuration = InitConfiguration.GetSettings();
            var mockLogger = getMockLogger();

            //Act
            var stringReader = new StringFileReader(configuration, mockLogger.Object);
            var fileContents = stringReader.ReadFromFile();

            //Assert
            Assert.NotZero(fileContents.Count);
        }

        [Test]
        public void StringFileReaderDoesNotReadEmptyLines()
        {
            //Arrange
            var configuration = InitConfiguration.GetSettings();
            var mockLogger = getMockLogger();

            //Act
            var stringReader = new StringFileReader(configuration, mockLogger.Object);
            var fileContents = stringReader.ReadFromFile();

            //Assert
            Assert.AreEqual(18,fileContents.Count);
        }
    }
}