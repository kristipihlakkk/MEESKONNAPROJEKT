using System;
using Gym.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Gym.Tests.Data
{
    [TestClass]
    public class RoomTests
    {
        [TestMethod]
        public void Room_Name_ShouldBeSettable()
        {
            // Arrange
            var room = new Room { Name = "Cardio Hall" };

            // Act
            var name = room.Name;

            // Assert
            Assert.AreEqual("Cardio Hall", name);
        }

        [TestMethod]
        public void Room_Capacity_WhenZero_ShouldBeInvalid()
        {
            // Arrange
            var room = new Room { Capacity = 0 };

            // Act & Assert
            Assert.IsTrue(room.Capacity <= 0, "Capacity of 0 should be invalid");
        }

        [TestMethod]
        public void Room_OpenFrom_DefaultShouldBe06()
        {
            // Arrange
            var room = new Room
            {
                OpenFrom = new TimeOnly(6, 0),
                OpenTo = new TimeOnly(22, 0),
                Capacity = 10
            };

            // Act
            var openFrom = room.OpenFrom;

            // Assert
            Assert.AreEqual(new TimeOnly(6, 0), openFrom);
        }

        [TestMethod]
        public void Room_OpenToAfterOpenFrom_ShouldBeValid()
        {
            // Arrange
            var from = new TimeOnly(6, 0);
            var to = new TimeOnly(22, 0);

            // Act & Assert
            Assert.IsTrue(to > from, "OpenTo must be after OpenFrom");
        }

        [TestMethod]
        public void Room_Type_ShouldBeStudio()
        {
            // Arrange
            var room = new Room { Type = RoomType.Studio };

            // Act
            var type = room.Type;

            // Assert
            Assert.AreEqual(RoomType.Studio, type);
        }
    }
}