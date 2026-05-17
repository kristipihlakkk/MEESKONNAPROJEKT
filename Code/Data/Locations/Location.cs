using Common;
using Gym.Aids;

namespace Gym.Data;

public class Location : BaseEntity {
    public Address Address { get; set; }
    public ICollection<LocationRooms> LocationRooms { get; set; } = [];
    public ICollection<Room> Rooms => [.. LocationRooms.Select(lr => lr.Room)];
}
