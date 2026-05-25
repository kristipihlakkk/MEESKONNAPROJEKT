using Common;
using System.Linq;
using System.Collections.Generic;

namespace Gym.Data;

public class Room : NamedEntity
{
    public int Capacity { get; set; }
    public RoomType Type { get; set; }
    public string Description { get; set; } = "";
    public TimeOnly OpenFrom { get; set; } = new TimeOnly(6, 0);
    public TimeOnly OpenTo { get; set; } = new TimeOnly(22, 0);
    public ICollection<RoomBookings> RoomBookings { get; set; } = new List<RoomBookings>();
    public IEnumerable<Booking?> Bookings =>
        RoomBookings?.Select(rb => rb.Booking) ?? Enumerable.Empty<Booking?>();
}

public enum RoomType
{
    Outside, Studio, Strength, Treatment, Meeting, Other
}