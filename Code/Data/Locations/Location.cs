using Common;
using Gym.Aids;
using System.Linq;
using System.Collections.Generic;

namespace Gym.Data;

public class Location : NamedEntity {
    // navigation properties can be null when not loaded; make them nullable
    public Address? Address { get; set; }
    // ensure collection is initialized to avoid null reference when enumerating
    public ICollection<LocationRooms> LocationRooms { get; set; } = new List<LocationRooms>();
    // return only non-null rooms and handle null LocationRooms safely
    public IEnumerable<Room> Rooms => LocationRooms?.Select(lr => lr.Room).Where(r => r != null) ?? Enumerable.Empty<Room>();
    public TimeOnly OpeningHours { get; set; } = new TimeOnly(6, 0);
    public TimeOnly ClosingHours { get; set; } = new TimeOnly(22, 0);
    public string AdditionalInfo { get; set; } = "";

}
