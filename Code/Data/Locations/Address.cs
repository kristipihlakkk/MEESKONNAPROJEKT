using Common;

namespace Gym.Data;

public class Address : BaseEntity {
    public string AddressLine1 { get; set; }
    public string? AddressLine2 { get; set; }
    public string City { get; set; }
    public string? PostalCode { get; set; }
    public string Country { get; set; }
}
