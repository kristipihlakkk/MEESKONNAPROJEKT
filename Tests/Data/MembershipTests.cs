using System;
using Gym.Data.Membership;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Gym.Tests.Data
{
    [TestClass]
    public class MembershipTests
    {
        [TestMethod]
        public void IsActive_WithActiveMembership_ShouldReturnTrue()
        {
            // Arrange
            var membership = new Membership
            {
                Status = MembershipStatus.Active,
                StartDate = DateTime.Now.AddDays(-1),
                EndDate = DateTime.Now.AddDays(30)
            };

            // Act
            var result = membership.IsActive();

            // Assert
            Assert.IsTrue(result, "Active membership should return true");
        }

        [TestMethod]
        public void IsActive_WithExpiredMembership_ShouldReturnFalse()
        {
            // Arrange
            var membership = new Membership
            {
                Status = MembershipStatus.Active,
                StartDate = DateTime.Now.AddDays(-60),
                EndDate = DateTime.Now.AddDays(-1)
            };

            // Act
            var result = membership.IsActive();

            // Assert
            Assert.IsFalse(result, "Expired membership should return false");
        }

        [TestMethod]
        public void IsActive_WithCancelledStatus_ShouldReturnFalse()
        {
            // Arrange
            var membership = new Membership
            {
                Status = MembershipStatus.Cancelled,
                StartDate = DateTime.Now.AddDays(-1),
                EndDate = DateTime.Now.AddDays(30)
            };

            // Act
            var result = membership.IsActive();

            // Assert
            Assert.IsFalse(result, "Cancelled membership should return false");
        }

        [TestMethod]
        public void DaysRemaining_WithActiveMembership_ShouldReturnPositive()
        {
            // Arrange
            var membership = new Membership
            {
                Status = MembershipStatus.Active,
                StartDate = DateTime.Now.AddDays(-1),
                EndDate = DateTime.Now.AddDays(10)
            };

            // Act
            var days = membership.DaysRemaining();

            // Assert
            Assert.IsTrue(days > 0, "Active membership should have positive days remaining");
        }

        [TestMethod]
        public void DaysRemaining_WithExpiredMembership_ShouldReturnZero()
        {
            // Arrange
            var membership = new Membership
            {
                Status = MembershipStatus.Active,
                StartDate = DateTime.Now.AddDays(-30),
                EndDate = DateTime.Now.AddDays(-1)
            };

            // Act
            var days = membership.DaysRemaining();

            // Assert
            Assert.AreEqual(0, days, "Expired membership should return 0 days remaining");
        }
    }
}