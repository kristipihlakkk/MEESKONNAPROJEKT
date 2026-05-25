using Gym.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Gym.Data;
 public sealed class Person : Party
    {
    [Required(ErrorMessage = "First name is required")]
    [RegularExpression(@"^[a-zA-Z\s\-']+$",
        ErrorMessage = "First name can only contain Latin letters, spaces, hyphens and apostrophes")]
    [CustomValidation(typeof(Person), nameof(ValidateAtLeastOneLetter))]
    public string FirstName { get; set; } = "";
    [Required]
    [RegularExpression(@"^[a-zA-Z\s\-']+$",
        ErrorMessage = "Last name can only contain Latin letters, spaces, hyphens and apostrophes")]
    [CustomValidation(typeof(Person), nameof(ValidateAtLeastOneLetter))]
    public string LastName { get; set; } = "";
    public DateTime? BirthDate { get; set; }
    [Required]
    [EmailAddress(ErrorMessage = "Invalid email format")]
    public string Email { get; set; } = "";
    public string FullName => $"{FirstName} {LastName}";


    public static ValidationResult ValidateAtLeastOneLetter(string value, ValidationContext context)
    {
        if (string.IsNullOrWhiteSpace(value))
            return ValidationResult.Success;

        if (!value.Any(char.IsLetter))
            return new ValidationResult("Must contain at least one letter");

        return ValidationResult.Success;
    }
}