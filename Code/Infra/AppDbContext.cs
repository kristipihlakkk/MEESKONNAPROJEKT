using Gym.Data;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
