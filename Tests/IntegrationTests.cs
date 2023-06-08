using DAL;
using DTO;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    internal class IntegrationTests
    {
        private readonly DataContext _context;
        private readonly HttpClient httpClient;

        //Om deze tests te runnen moet je naar bin\Debug\net6.0 directory en de exe van de applicatie runnen
        public IntegrationTests(WebApplicationFactory<Program> factory)
        {
            _context = CreateInMemoryProductContext();
            SeedDatabase();

            httpClient = factory
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        services.AddScoped(_ => _context);
                    });
                })
                .CreateClient();

            //Voor het weghalen van certificate errors
            var handler = new HttpClientHandler()
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
            };
            httpClient = new HttpClient(handler);
            httpClient.BaseAddress = new Uri("https://localhost:5001/");
        }

        public DataContext CreateInMemoryProductContext()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            var context = new DataContext(options);
            
            context.Database.EnsureCreated();

            return context;
        }

        private void SeedDatabase()
        {
            var dummyMouse = new Mouse { Id = 1, Name = "Mouse 1", Brand = "Brand 1", Weight = 5, Sensor = "Sensor 1" };
            _context.Mice.Add(dummyMouse);
            _context.SaveChanges();
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

            Assert.IsNotEmpty(responseContent);
            //Assert.IsTrue(responseContent.Contains(GetMiceFromDatabase));
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


    }
}
