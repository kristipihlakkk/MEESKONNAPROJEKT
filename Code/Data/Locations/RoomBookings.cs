using Gym.Aids;
using Common;
using System.Collections.Generic;
using System.Text;

namespace Gym.Data;

public class RoomBookings : BaseEntity {
    [Select(typeof(Booking), nameof(Booking.Id))] public Guid? BookingId { get; set; }
    [Select(typeof(Room), nameof(Room.Id))] public Guid? RoomId { get; set; }
    public Room? Room { get; set; }
    public Booking? Booking { get; set; }
}
