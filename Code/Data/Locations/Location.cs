using Common;
using Gym.Aids;

namespace Gym.Data;

public class Location : NamedEntity {
    public Address Address { get; set; }
    public ICollection<LocationRooms> LocationRooms { get; set; } = [];
    public ICollection<Room> Rooms => [.. LocationRooms.Select(lr => lr.Room)];
    public TimeOnly OpeningHours { get; set; } = new TimeOnly(6, 0);
    public TimeOnly ClosingHours { get; set; } = new TimeOnly(22, 0);
    public string AdditionalInfo { get; set; } = "";

}
