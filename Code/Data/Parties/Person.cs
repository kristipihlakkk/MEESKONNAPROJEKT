using Gym.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Gym.Data;
 public sealed class Person : Party
    {
    [Required] public string FirstName { get; set; } = string.Empty;
    [Required] public string LastName { get; set; } = string.Empty;
    public DateTime? BirthDate { get; set; }
    [Required][EmailAddress] public string Email { get; set; } = string.Empty;
    public string FullName => $"{FirstName} {LastName}";
}
