using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Gym.Data;

namespace Gym.Tests.Data
{
    [TestClass]
    public class PersonTests
    {
        [TestMethod]
        public void FullName_ShouldReturnFirstNameAndLastName()
        {
            // Arrange
            var person = new Person { FirstName = "John", LastName = "Doe" };

            // Act
            var fullName = person.FullName;

            // Assert
            Assert.AreEqual("John Doe", fullName);
        }

        [TestMethod]
        public void FullName_WithEmptyFirstName_ShouldReturnOnlyLastName()
        {
            // Arrange
            var person = new Person { FirstName = "", LastName = "Doe" };

            // Act
            var fullName = person.FullName;

            // Assert
            Assert.AreEqual(" Doe", fullName);
        }

        [TestMethod]
        public void FullName_WithEmptyLastName_ShouldReturnOnlyFirstName()
        {
            // Arrange
            var person = new Person { FirstName = "John", LastName = "" };

            // Act
            var fullName = person.FullName;

            // Assert
            Assert.AreEqual("John ", fullName);
        }

        [TestMethod]
        public void FirstName_ShouldHaveRequiredAttribute()
        {
            // Arrange
            var property = typeof(Person).GetProperty("FirstName");

            // Act
            var attributes = property.GetCustomAttributes(typeof(RequiredAttribute), true);

            // Assert
            Assert.IsTrue(attributes.Length > 0, "FirstName should have [Required] attribute");
        }

        [TestMethod]
        public void LastName_ShouldHaveRequiredAttribute()
        {
            // Arrange
            var property = typeof(Person).GetProperty("LastName");

            // Act
            var attributes = property.GetCustomAttributes(typeof(RequiredAttribute), true);

            // Assert
            Assert.IsTrue(attributes.Length > 0, "LastName should have [Required] attribute");
        }

        [TestMethod]
        public void Email_ShouldHaveRequiredAndEmailAddressAttributes()
        {
            // Arrange
            var property = typeof(Person).GetProperty("Email");

            // Act
            var requiredAttributes = property.GetCustomAttributes(typeof(RequiredAttribute), true);
            var emailAttributes = property.GetCustomAttributes(typeof(EmailAddressAttribute), true);

            // Assert
            Assert.IsTrue(requiredAttributes.Length > 0, "Email should have [Required] attribute");
            Assert.IsTrue(emailAttributes.Length > 0, "Email should have [EmailAddress] attribute");
        }
    }
}
