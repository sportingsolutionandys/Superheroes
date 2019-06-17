using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using SuperHeroes.Models;
using Xunit;

namespace SuperHeroesIntegrationTest
{
    public class SuperHeroesControllerTests : IClassFixture<WebApplicationFactory<SuperHeroes.Startup>>
    {
        private readonly WebApplicationFactory<SuperHeroes.Startup> _factory;

        public SuperHeroesControllerTests(WebApplicationFactory<SuperHeroes.Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/api/superheroes")]
        public async Task Get_SuperHeroesControllerReturnsSuccessAndJSONContentType(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("application/json; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }

        [Theory]
        [InlineData("/api/superheroes")]
        public async Task Get_SuperHeroesControllerReturnsSuccessAndXMLContentType(string url)
        {
            // Arrange
            var clientOptions = new WebApplicationFactoryClientOptions();

            var client = _factory.CreateClient();
            //Add xml accept type in header
            client.DefaultRequestHeaders.Add("Accept", "application/xml");

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("application/xml; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }

        [Theory]
        [InlineData("/api/superheroes")]
        public async Task Get_SuperHeroesControllerReturnsCharacters(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            var characters = response.Content.ReadAsAsync<Characters>();

            //Check that there are characters returned
            var totalCountofCharacters = characters.Result.Superheroes.Count + characters.Result.Villains.Count;
            Assert.NotEqual(0,totalCountofCharacters);
        }


    }
}
