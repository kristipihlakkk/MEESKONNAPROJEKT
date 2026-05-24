
using Gym.Data;
using Gym.Data.Membership;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


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
            .Include(l => l.LocationRooms)
            .FirstOrDefaultAsync(l => l.Id == id);

    public override async Task<IEnumerable<Location>> GetAsync(Query query)
        => await _context.Locations
            .Include(l => l.Address)
            .Include(l => l.LocationRooms)
            .ToListAsync();
}

public sealed class RoomsRepo : BaseRepo<Room>, IRoomsRepo
{
    public RoomsRepo(AppDbContext context) : base(context) { }

    public override async Task<Room?> GetAsync(Guid id)
        => await _context.Rooms
            .FirstOrDefaultAsync(r => r.Id == id);

    public override async Task<IEnumerable<Room>> GetAsync(Query query)
        => await _context.Rooms.ToListAsync();

    public sealed class VisitsRepo : BaseRepo<Visit>, IVisitsRepo
    {
        public VisitsRepo(AppDbContext context) : base(context) { }
    }
    public sealed class MembershipsRepo : BaseRepo<Membership>, IMembershipsRepo
    {
        public MembershipsRepo(AppDbContext context) : base(context) { }
    }
}
