using Gym.Data.Common;
using System.Net;

namespace Gym.Data;
// Silverstoni järgi peavad Address ja ContactMethod olema ERALDI tabelites
public class Person : Party
{
    public string PersonalCode { get; set; } = string.Empty;
    public DateTime? DateOfBirth { get; set; }
    public string Gender { get; set; } = string.Empty;

    // Silverston: aadressid eraldi tabelis
    public virtual ICollection<Address> Addresses { get; set; }
    = new List<Address>();

    // Silverston: kontaktid eraldi tabelis
   public virtual ICollection<ContactMethod> ContactMethods { get; set; }
   = new List<ContactMethod>();
}