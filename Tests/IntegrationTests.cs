using DAL;
using DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    internal class IntegrationTests
    {

        private readonly HttpClient httpClient;

        //Om deze tests te runnen moet je naar bin\Debug\net6.0 directory en de exe van de applicatie runnen
        public IntegrationTests()
        {
            //Arrange

            //Voor het weghalen van certificate errors
            var handler = new HttpClientHandler()
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
            };
            httpClient = new HttpClient(handler);
            httpClient.BaseAddress = new Uri("https://localhost:5001/");
        }

        [Test]
        public async Task TestGetMice()
        {
            // Arrange
            
            // Act
            HttpResponseMessage response = await httpClient.GetAsync("mouse");
            string responseContent = await response.Content.ReadAsStringAsync();


            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            //Assert.IsNotEmpty(responseContent);
            //Assert.IsTrue(responseContent.Contains(GetMiceFromDatabase));
        }

        private List<Mouse> GetMiceFromDatabase(DataContext context)
        {
            return context.Mice.ToList();
        }

        [Test]
        public async Task TestGetMods()
        {
            // Arrange

            // Act
            HttpResponseMessage response = await httpClient.GetAsync("mod");
            string responseContent = await response.Content.ReadAsStringAsync();


            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            //Assert.IsNotEmpty(responseContent);
            //Assert.IsTrue(responseContent.Contains(GetModsFromDatabase));
        }

        private List<MouseMod> GetModsFromDatabase(DataContext context)
        {
            return context.Mods.ToList();
        }
    }
}
