using System;
using Microsoft.Extensions.Logging;
using Moq;

namespace SuperHeroesUnitTests.HelperMethods
{
    public class MockLogger
    {
        public static Mock<ILogger<T>> GetLogger<T>()
        {
            return new Mock<ILogger<T>>();
        }
    }
}
