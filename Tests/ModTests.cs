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

        [Test]
        public void AddMod_Success()
        {
            //Arrange
            Mouse BaseMouse = new Mouse { Id = 1, Name = "name2", Brand = "brand 2", Image = "link to image", Sensor = "sensor 2", Weight = 20 };

            var mockRepo = new Mock<IModHandler>();
            var mouseRepo = new Mock<IMouseHandler>();

            // Zodat ik getById kan gebruiken die in addmod gebruikt wordt
            mouseRepo.Setup(x => x.getById(It.IsAny<int>())).Returns(BaseMouse);

            MouseMod capturedMod = null;
            mockRepo.Setup(x => x.AddMod(It.IsAny<MouseMod>()))
                    .Callback<MouseMod>(mod => capturedMod = mod);

            var _modLogic = new ModLogic(mockRepo.Object, mouseRepo.Object);

            //Act
            _modLogic.AddMod(1, 23, "a comment", "user1");

            //Assert
            Assert.IsNotNull(capturedMod, "capturedMod is null");
            Assert.AreEqual("user1", capturedMod.auth0Id, "auth0Id is niet hetzelfde");
            Assert.AreEqual(BaseMouse, capturedMod.Base, "Base is niet hetzelfde");
            Assert.AreEqual("a comment", capturedMod.Comments, "Comments is niet hetzelfde");
            Assert.AreEqual(23, capturedMod.Weight, "Weight is niet hetzelfde");
        }

        [Test]
        public void GetModsByUser_Success()
        {
            // Arrange
            Mouse BaseMouse = new Mouse { Name = "name2", Brand = "brand 2", Image = "link to image", Sensor = "sensor 2", Weight = 20 };
            List<MouseMod> ListInMock = new List<MouseMod>
            {
                new MouseMod{ auth0Id="id", Base=BaseMouse, Comments="Some Comment", Weight = 5},
                new MouseMod{ auth0Id="id", Base=BaseMouse, Comments="Another Comment", Weight = 15},
                new MouseMod{ auth0Id="id2", Base=BaseMouse, Comments="Another Comment", Weight = 25}
            };

            var mockRepo = new Mock<IModHandler>();
            var mouseRepo = new Mock<IMouseHandler>();

            mockRepo.Setup(x => x.getModsByUser(It.IsAny<string>()))
                    .Returns((string uid) => ListInMock.Where(mod => mod.auth0Id == uid).ToList());

            var _modLogic = new ModLogic(mockRepo.Object, mouseRepo.Object);

            // Act
            var selectedMods = _modLogic.getModsByUser("id");

            // Assert
            List<MouseMod> checkList = ListInMock.Where(x => x.auth0Id == "id").ToList();
            Assert.That(selectedMods, Is.EquivalentTo(checkList));
        }


    }
}
