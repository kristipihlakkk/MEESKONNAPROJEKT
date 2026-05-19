using Common;
using System.ComponentModel.DataAnnotations;

namespace Gym.Data.Locations;

public enum ContactType
{
    Phone,
    Email,
    Other
}

public class ContactMethod : BaseEntity
{
    [Required]
    public ContactType Type { get; set; }

    [Required]
    public string Value { get; set; } = string.Empty;
}