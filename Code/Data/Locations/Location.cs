using Common;
using Gym.Aids;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gym.Data;

public class Location : NamedEntity {
    public Address? Address { get; set; }
    public ICollection<LocationRooms> LocationRooms { get; set; } = new List<LocationRooms>();
    public TimeOnly OpeningHours { get; set; } = new TimeOnly(6, 0);
    public TimeOnly ClosingHours { get; set; } = new TimeOnly(22, 0);
    public string AdditionalInfo { get; set; } = "";
}
