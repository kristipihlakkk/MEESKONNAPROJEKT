using Gym.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Gym.Data;
 public sealed class Person : Party
    {
        [Required]
        [StringLength(100)]
        [DisplayName("First Name")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        [DisplayName("Last Name")]
        public string LastName { get; set; } = string.Empty;

        [DisplayName("Birth Date")]
        public DateTime? BirthDate { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        public string FullName => $"{FirstName} {LastName}";
    }
