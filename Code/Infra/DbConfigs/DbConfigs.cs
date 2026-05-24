using Gym.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gym.Infra;

public sealed class PersonConfig : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> b)
    {
        b.Ignore(x => x.FullName);
    }
}

public sealed class LocationConfig : IEntityTypeConfiguration<Location> {
    public void Configure(EntityTypeBuilder<Location> b) { }
}

public sealed class RoomConfig : IEntityTypeConfiguration<Room> {
    public void Configure(EntityTypeBuilder<Room> b) { }
}
public sealed class BookingConfig : IEntityTypeConfiguration<Booking>
{
    public void Configure(EntityTypeBuilder<Booking> b) { }
}

public sealed class LocationRoomsConfig : IEntityTypeConfiguration<LocationRooms>
{
    public void Configure(EntityTypeBuilder<LocationRooms> b) {
        b.HasOne(x => x.Location)
            .WithMany(x => x.LocationRooms)
            .HasForeignKey(x => x.LocationId);
        b.HasOne(x => x.Room).WithMany().HasForeignKey(x => x.RoomId);
    }
}

public sealed class RoomBookingConfig : IEntityTypeConfiguration<RoomBookings>
{
    public void Configure(EntityTypeBuilder<RoomBookings> b) {
        b.HasOne(x => x.Room).WithMany(x => x.RoomBookings).HasForeignKey(x => x.RoomId);
        b.HasOne(x => x.Booking).WithMany().HasForeignKey(x => x.BookingId);
    }
}