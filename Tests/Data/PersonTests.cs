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

        [TestMethod]
        public void FirstName_WithTwoCharacters_ShouldPassValidation()
        {
            var person = new Person { FirstName = "Jo", LastName = "Doe", Email = "john@test.com" };
            var results = ValidatePerson(person);

            Assert.IsTrue(results.IsValid);
        }

        

        // 3. только латиница
        [TestMethod]
        public void FirstName_WithCyrillic_ShouldFailValidation()
        {
            var person = new Person { FirstName = "Иван", LastName = "Doe", Email = "john@test.com" };
            var results = ValidatePerson(person);

            Assert.IsFalse(results.IsValid);
            Assert.IsTrue(results.Errors.Any(e => e.ErrorMessage.Contains("Latin letters")));
        }

        [TestMethod]
        public void FirstName_WithNumbers_ShouldFailValidation()
        {
            var person = new Person { FirstName = "John123", LastName = "Doe", Email = "john@test.com" };
            var results = ValidatePerson(person);

            Assert.IsFalse(results.IsValid);
        }

        [TestMethod]
        public void FirstName_WithSpecialCharacters_ShouldFailValidation()
        {
            var person = new Person { FirstName = "John@#$", LastName = "Doe", Email = "john@test.com" };
            var results = ValidatePerson(person);

            Assert.IsFalse(results.IsValid);
        }

        [TestMethod]
        public void FirstName_WithHyphen_ShouldPassValidation()
        {
            var person = new Person { FirstName = "Mary-Jane", LastName = "Doe", Email = "john@test.com" };
            var results = ValidatePerson(person);

            Assert.IsTrue(results.IsValid);
        }

        [TestMethod]
        public void FirstName_WithApostrophe_ShouldPassValidation()
        {
            var person = new Person { FirstName = "O'Connor", LastName = "Doe", Email = "john@test.com" };
            var results = ValidatePerson(person);

            Assert.IsTrue(results.IsValid);
        }

        [TestMethod]
        public void FirstName_WithSpace_ShouldPassValidation()
        {
            var person = new Person { FirstName = "Anne Marie", LastName = "Doe", Email = "john@test.com" };
            var results = ValidatePerson(person);

            Assert.IsTrue(results.IsValid);
        }

        // 4. хотя бы одна буква
        [TestMethod]
        public void FirstName_OnlyHyphens_ShouldFailValidation()
        {
            var person = new Person { FirstName = "---", LastName = "Doe", Email = "john@test.com" };
            var results = ValidatePerson(person);

            Assert.IsFalse(results.IsValid);
            Assert.IsTrue(results.Errors.Any(e => e.ErrorMessage.Contains("at least one letter")));
        }

        [TestMethod]
        public void FirstName_OnlyApostrophes_ShouldFailValidation()
        {
            var person = new Person { FirstName = "'''", LastName = "Doe", Email = "john@test.com" };
            var results = ValidatePerson(person);

            Assert.IsFalse(results.IsValid);
        }

        [TestMethod]
        public void FirstName_OnlySpaces_ShouldFailValidation()
        {
            var person = new Person { FirstName = "   ", LastName = "Doe", Email = "john@test.com" };
            var results = ValidatePerson(person);

            Assert.IsFalse(results.IsValid);
        }

        // 5. ПРОВЕРКИ ДЛЯ LASTNAME
        [TestMethod]
        public void LastName_WithNumbers_ShouldFailValidation()
        {
            var person = new Person { FirstName = "John", LastName = "Doe123", Email = "john@test.com" };
            var results = ValidatePerson(person);

            Assert.IsFalse(results.IsValid);
        }

        [TestMethod]
        public void LastName_OnlyHyphens_ShouldFailValidation()
        {
            var person = new Person { FirstName = "John", LastName = "---", Email = "john@test.com" };
            var results = ValidatePerson(person);

            Assert.IsFalse(results.IsValid);
        }

        // 6. ПРОВЕРКА EMAIL
        [TestMethod]
        public void Email_WithoutAtSymbol_ShouldFailValidation()
        {
            var person = new Person { FirstName = "John", LastName = "Doe", Email = "johnexample.com" };
            var results = ValidatePerson(person);

            Assert.IsFalse(results.IsValid);
        }

        [TestMethod]
        public void Email_WithoutDomain_ShouldFailValidation()
        {
            var person = new Person { FirstName = "John", LastName = "Doe", Email = "john@" };
            var results = ValidatePerson(person);

            Assert.IsFalse(results.IsValid);
        }

        [TestMethod]
        public void Email_ValidFormat_ShouldPassValidation()
        {
            var person = new Person { FirstName = "John", LastName = "Doe", Email = "john@example.com" };
            var results = ValidatePerson(person);

            Assert.IsTrue(results.IsValid);
        }

        // 7. ВСПОМОГАТЕЛЬНЫЙ МЕТОД ДЛЯ ВАЛИДАЦИИ
        private (bool IsValid, List<ValidationResult> Errors) ValidatePerson(Person person)
        {
            var context = new ValidationContext(person);
            var results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(person, context, results, true);
            return (isValid, results);
        }
    }
}