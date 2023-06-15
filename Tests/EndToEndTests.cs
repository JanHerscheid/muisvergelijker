using DAL;
using DTO;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Net;

namespace Tests
{
    [TestFixture]
    internal class EndToEndTests
    {
        private readonly HttpClient httpClient;

        //Om deze tests te runnen moet je naar bin\Debug\net6.0 directory en de exe van de applicatie runnen
        public EndToEndTests()
        {
            //Voor het weghalen van certificate errors
            var handler = new HttpClientHandler()
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
            };
            httpClient = new HttpClient(handler);
            httpClient.BaseAddress = new Uri("https://localhost:5001/");
        }

        [Test]
        public async Task GetAllMice_Success()
        {
            // Arrange
            using var application = new WebApplicationFactory<Program>();
            var client = application.CreateClient();

            // Act
            var mice = await client.GetAsync("/mouse");

            // Assert
            Assert.IsNotNull(mice);
        }

        [Test]
        public async Task GetAllMods_Success()
        {
            // Arrange
            using var application = new WebApplicationFactory<Program>();
            var client = application.CreateClient();

            // Act
            var mods = await client.GetAsync("/mod");

            // Assert
            Assert.IsNotNull(mods);
        }

        [Test]
        public async Task GetAllMods_Fail()
        {
            // Arrange
            using var application = new WebApplicationFactory<Program>();
            var client = application.CreateClient();

            // Act
            var mods = await client.GetAsync("/mods");

            // Assert
            Assert.AreEqual(HttpStatusCode.NotFound, mods.StatusCode);
        }

        [Test]
        public async Task GetAllMice_Fail()
        {
            // Arrange
            using var application = new WebApplicationFactory<Program>();
            var client = application.CreateClient();

            // Act
            var mice = await client.GetAsync("/mice");

            // Assert
            Assert.AreEqual(HttpStatusCode.NotFound, mice.StatusCode);
        }
    }
}