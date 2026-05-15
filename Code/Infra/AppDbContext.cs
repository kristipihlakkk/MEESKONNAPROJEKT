using Gym.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Abc.Data;

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
    }
}
