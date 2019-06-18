using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using SuperHeroes.Implementation;
using SuperHeroesUnitTests.HelperMethods;

namespace SuperHeroesUnitTests
{
    public class ContainsDRuleUnitTests
    {
        public Mock<ILogger<ContainsDRule>> getMockLogger()
        {
            return MockLogger.GetLogger<ContainsDRule>();
        }

        public List<string> testInputContents = new List<string>() 
        { "Bad Guy", "Good Guy", "OlD guy 1", "Old Guy 2", "Death"}; 

        [Test]
        public void ContainsDRuleSperatesCharactersCorrectly()
        {
            //Arrange
            var mockLogger = getMockLogger();
            var containsDRule = new ContainsDRule(mockLogger.Object);

            //Act
            var characters = containsDRule.ApplyRule(testInputContents);
            var villainsCount = characters.Villains.Count;
            var superHeroesCount = characters.Superheroes.Count;
            
            //Assert
            Assert.AreEqual(2, villainsCount);
            Assert.AreEqual(3, superHeroesCount);

        }

        [Test]
        public void ContainsDRuleOnlySperatesUppercaseD()
        {
            //Arrange
            var mockLogger = getMockLogger();
            var containsDRule = new ContainsDRule(mockLogger.Object);

            //Act
            var characters = containsDRule.ApplyRule(testInputContents);
            var villainsContainsOldGuy2 = characters.Villains.Contains("Old Guy 2");

            //Assert
            Assert.IsFalse(villainsContainsOldGuy2);

        }
    }
}
