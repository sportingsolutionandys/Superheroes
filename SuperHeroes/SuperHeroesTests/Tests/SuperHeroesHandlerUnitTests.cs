using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using SuperHeroes.Controllers;
using SuperHeroes.Implementation;
using SuperHeroes.Interfaces;
using SuperHeroes.Models;

namespace SuperHeroesUnitTests
{
    public class SuperHeroesHandlerUnitTests
    {
        [Test]
        public void SuperHeroesHandlerShouldReturnListOfCharactersSuccessfully()
        {
            //Arrange
            var dummyList = new List<string>() { "character bad", "character good" };

            var mockIFileReader = new Mock<IFileReader<string>>();
            mockIFileReader.Setup(x => x.ReadFromFile())
                  .Returns(dummyList);

            var mockSuperHeroesRule = new Mock<ISuperHeroesRule>();
            mockSuperHeroesRule.Setup(x => x.ApplyRule(dummyList))
                  .Returns(new Characters() { Villains = new List<string>() { "Villain1"} });

            var superHeroesHandler = new SuperHeroesHandler(mockIFileReader.Object, mockSuperHeroesRule.Object);

            //Act
            var result = superHeroesHandler.GetCharacters();
            var villains = result.Villains;

            //Assert
            Assert.That(villains, Has.Exactly(1).Items);
        }

        [Test]
        public void SuperHeroesHandlerShouldRemoveDuplicatesReadFromFile()
        {
            //Arrange
            var dummyList = new List<string>() { "test", "test2", "test" };

            var mockIFileReader = new Mock<IFileReader<string>>();

            var mockSuperHeroesRule = new Mock<ISuperHeroesRule>();

            var superHeroesHandler = new SuperHeroesHandler(mockIFileReader.Object, mockSuperHeroesRule.Object);

            //Act
            var result = superHeroesHandler.RemoveDuplicatesFromList(dummyList);

            //Assert
            Assert.That(result, Is.Unique);
        }
    }
}
