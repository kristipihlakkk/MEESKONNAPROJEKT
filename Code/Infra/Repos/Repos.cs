using Gym.Data;
using Gym.Data.Membership;
using Microsoft.EntityFrameworkCore;

namespace Gym.Infra;

public sealed class PersonsRepo : BaseRepo<Person>, IPersonsRepo
{
    public PersonsRepo(AppDbContext context) : base(context) { }

    public override async Task<Person?> GetAsync(Guid id)
        => await _context.Persons
            .Include(p => p.Addresses)
            .Include(p => p.ContactMethods)
            .FirstOrDefaultAsync(p => p.Id == id);

    public override async Task<IEnumerable<Person>> GetAsync(Query query)
        => await _context.Persons
            .Include(p => p.Addresses)
            .Include(p => p.ContactMethods)
            .ToListAsync();
}

public sealed class LocationsRepo : BaseRepo<Location>, ILocationsRepo
{
    public LocationsRepo(AppDbContext context) : base(context) { }

    public override async Task<Location?> GetAsync(Guid id)
        => await _context.Locations
            .Include(l => l.Address)
            .Include(l => l.LocationRooms)!.ThenInclude(lr => lr.Room)
            .FirstOrDefaultAsync(l => l.Id == id);

    public override async Task<IEnumerable<Location>> GetAsync(Query q)
        => await _context.Locations
            .Include(l => l.Address)
            .Include(l => l.LocationRooms)!.ThenInclude(lr => lr.Room)
            .ToListAsync();
}

public class RoomsRepo(AppDbContext c = null)
    : EfBaseRepo<AppDbContext, Room>(c), IRoomsRepo { }

public class AddressesRepo(AppDbContext c = null)
    : EfBaseRepo<AppDbContext, Address>(c), IAddressesRepo { }

    public override async Task<IEnumerable<Room>> GetAsync(Query query)
        => await _context.Rooms.ToListAsync();
}
public class LocationRoomsRepo(AppDbContext c = null)
    : EfBaseRepo<AppDbContext, LocationRooms>(c), ILocationRoomsRepo { }


public sealed class BookingsRepo : BaseRepo<Booking>, IBookingsRepo
{
    public BookingsRepo(AppDbContext context) : base(context) { }

    public override async Task<Booking?> GetAsync(Guid id)
        => await _context.Set<Booking>()
            .Include(b => b.BookedBy)
            .Include(b => b.RoomBookings)!.ThenInclude(rb => rb.Room)
            .FirstOrDefaultAsync(b => b.Id == id);

        public override async Task<IEnumerable<Booking>> GetAsync(Query query)
            => await _context.Set<Booking>()
                .Include(b => b.BookedBy)
                .Include(b => b.RoomBookings)!.ThenInclude(rb => rb.Room)
                .ToListAsync();
}

public class RoomBookingsRepo(AppDbContext c = null)
    : EfBaseRepo<AppDbContext, RoomBookings>(c), IRoomBookingsRepo { }
public sealed class MembershipsRepo : BaseRepo<Membership>, IMembershipsRepo {
    public MembershipsRepo(AppDbContext context) : base(context) { }
}

public sealed class VisitsRepo : BaseRepo<Visit>, IVisitsRepo {
    public VisitsRepo(AppDbContext context) : base(context) { }
}
public sealed class VisitsRepo : BaseRepo<Visit>, IVisitsRepo
{
    public VisitsRepo(AppDbContext context) : base(context) { }
}

public sealed class MembershipsRepo : BaseRepo<Membership>, IMembershipsRepo
{
    public MembershipsRepo(AppDbContext context) : base(context) { }
}

public sealed class TrainersRepo : BaseRepo<Trainer>, ITrainersRepo
{
    public TrainersRepo(AppDbContext context) : base(context) { }

    public override async Task<Trainer?> GetAsync(Guid id)
        => await _context.Trainers
            .Include(t => t.Person)
            .FirstOrDefaultAsync(t => t.Id == id);

    public override async Task<IEnumerable<Trainer>> GetAsync(Query query)
        => await _context.Trainers
            .Include(t => t.Person)
            .ToListAsync();
}