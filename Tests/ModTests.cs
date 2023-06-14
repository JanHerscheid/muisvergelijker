using DAL.Interfaces;
using DTO;
using Logic;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class ModTests
    {
        [SetUp]
        public void setup()
        {

        }

        [Test]
        public void GetAllMods_Success()
        {
            //Arrange
            Mouse BaseMouse = new Mouse { Name = "name2", Brand = "brand 2", Image = "link to image", Sensor = "sensor 2", Weight = 20 };
            List<MouseMod> ListInMock = new List<MouseMod>
            {
                new MouseMod{ auth0Id="id", Base=BaseMouse, Comments="Some Comment", Weight = 5},
                new MouseMod{ auth0Id="id", Base=BaseMouse, Comments="Another Comment", Weight = 15},
            };

            var mockRepo = new Mock<IModHandler>();
            var mouseRepo = new Mock<IMouseHandler>();
            mockRepo.Setup(x => x.GetAll()).Returns(ListInMock);

            var _modLogic = new ModLogic(mockRepo.Object, mouseRepo.Object);

            //Act
            var allMods = _modLogic.GetAll();

            //Assert
            mockRepo.Verify(x => x.GetAll(), Times.Once);
            Assert.That(allMods, Is.EquivalentTo(ListInMock));
        }
    }
}
