using Common;
using System.Linq;
using System.Collections.Generic;

namespace Gym.Data;

public class Room : NamedEntity {
    public int Capacity { get; set; }
    public RoomType Type { get; set; }
    public string Description { get; set; } = "";
    // initialize collection and make navigation nullable-aware
    public ICollection<RoomBookings> RoomBookings { get; set; } = new List<RoomBookings>();
    public IEnumerable<Booking?> Bookings => RoomBookings?.Select(rb => rb.Booking) ?? Enumerable.Empty<Booking?>();
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
