using Gym.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Gym.Infra
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(
            DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }

        public DbSet<Trainer> Trainers { get; set; }

        public DbSet<GymMember> GymMembers { get; set; }

        public DbSet<Membership> Memberships { get; set; }

        public DbSet<Visit> Visits { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<LocationRooms> LocationRooms { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Holiday> Holidays { get; set; }
        public DbSet<OpenCloseTimes> OpenCloseTimes { get; set; }

    }
}
