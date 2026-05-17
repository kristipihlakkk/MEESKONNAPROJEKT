using Common;

namespace Gym.Data;

public class Room : NamedEntity {
    public int Capacity { get; set; }
    public DateOnly date { get; set; }
    public TimeOnly OpenFrom { get; set; } = new TimeOnly(6, 0);
    public TimeOnly OpenTo { get; set; } = new TimeOnly(22, 0);
    public RoomType Type { get; set; }
    public string Description { get; set; } = "";
    public ICollection<RoomBookings> RoomBookings { get; set; } = [];
    public ICollection<Booking> Bookings => [.. RoomBookings.Select(rb => rb.Booking)];
}

public enum RoomType {
    Outside,
    Studio,
    Spin,
    Cardio,
    Strength,
    Court,
    Treatment,
    Meeting,
    Other
}
