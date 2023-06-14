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
    public class MouseTests
    {
        [SetUp]
        public void setup()
        {

        }

        [Test]
        public void GetAllMice_Success()
        {
            //Arrange
            List<Mouse> ListInMock = new List<Mouse>
            {
                new Mouse{ Name = "name1", Brand = "brand 1", Image = "link to image", Sensor = "sensor 1", Weight = 10},
                new Mouse{ Name = "name2", Brand = "brand 2", Image = "link to image", Sensor = "sensor 2", Weight = 20},
            };
            var mockRepo = new Mock<IMouseHandler>();
            mockRepo.Setup(x => x.GetAll()).Returns(ListInMock);

            var _mouseLogic = new MouseLogic(mockRepo.Object);

            //Act
            var allMice = _mouseLogic.GetAll();

            //Assert
            mockRepo.Verify(x => x.GetAll(), Times.Once);
            Assert.That(allMice, Is.EquivalentTo(ListInMock));
        }

        [Test]
        public void AddMouse_Succes()
        {
            //Arrange
            List<Mouse> ListInMock = new List<Mouse>
            {
                new Mouse{ Name = "name1", Brand = "brand 1", Image = "link to image", Sensor = "sensor 1", Weight = 10},
                new Mouse{ Name = "name2", Brand = "brand 2", Image = "link to image", Sensor = "sensor 2", Weight = 20},
            };
            var mockRepo = new Mock<IMouseHandler>();

            var _mouseLogic = new MouseLogic(mockRepo.Object);

            Mouse MouseToAdd = new Mouse { Name = "name3", Brand = "brand 3", Image = "link to image", Sensor = "sensor 3", Weight = 20 };

            //Act
            _mouseLogic.AddMouse(MouseToAdd);

            //Assert
            mockRepo.Verify(x => x.AddMouse(MouseToAdd), Times.Once);
        }
    }
}
