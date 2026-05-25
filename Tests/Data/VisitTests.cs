using System;
using Gym.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Gym.Tests.Data
{
    [TestClass]
    public class VisitTests
    {
        [TestMethod]
        public void Visit_Notes_ShouldContainPersonIdAndName()
        {
            // Arrange
            var personId = Guid.NewGuid();
            var visit = new Visit
            {
                VisitDate = DateTime.Now,
                Notes = $"{personId}|John Doe|Cardio Hall"
            };

            // Act
            var parts = visit.Notes.Split('|');

            // Assert
            Assert.AreEqual(3, parts.Length);
            Assert.AreEqual(personId.ToString(), parts[0]);
            Assert.AreEqual("John Doe", parts[1]);
            Assert.AreEqual("Cardio Hall", parts[2]);
        }

        [TestMethod]
        public void Visit_FutureDate_ShouldBeDetectable()
        {
            // Arrange
            var visit = new Visit { VisitDate = DateTime.Now.AddDays(1) };

            // Act & Assert
            Assert.IsTrue(visit.VisitDate > DateTime.Now, "Future visit date should be detectable");
        }

        [TestMethod]
        public void Visit_PastDate_ShouldBeValid()
        {
            // Arrange
            var visit = new Visit { VisitDate = DateTime.Now.AddHours(-2) };

            // Act & Assert
            Assert.IsTrue(visit.VisitDate <= DateTime.Now, "Past visit date should be valid");
        }

        [TestMethod]
        public void Visit_NullNotes_ShouldHandleGracefully()
        {
            // Arrange
            var visit = new Visit { VisitDate = DateTime.Now, Notes = null };

            // Act
            var parts = visit.Notes?.Split('|') ?? Array.Empty<string>();

            // Assert
            Assert.AreEqual(0, parts.Length);
        }
    }
}