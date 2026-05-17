using Common;

namespace Gym.Data;

public class Booking : BaseEntity {
    public Guid Id { get; set; }
    public string BookingTitle { get; set; }
    public Person BookedBy { get; set; }
    public DateTimeOffset StartsAt { get; set; }
    public DateTimeOffset EndsAt { get; set; }
    public bool Status { get; set; }
    public string? Notes { get; set; }
    public bool IsValidTimeRange => EndsAt > StartsAt;
    public RoomBookings RoomBookings { get; set; }
}
