using Common;
using Gym.Aids;

namespace Gym.Data;

public class LocationRooms: BaseEntity {
    [Select(typeof(Location), nameof(Location.Id))] public Guid? LocationId { get; set; }
    [Select(typeof(Room), nameof(Room.Id))] public Guid? RoomId { get; set; }
    public Room? Room { get; set; }
    public Location? Location { get; set; }

}
