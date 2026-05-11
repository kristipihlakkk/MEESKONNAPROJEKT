using Gym.Data;
using Gym.Infra;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Infra;

public sealed class PersonsRepo
    : BaseRepo<Person>, IPersonsRepo
{
    public PersonsRepo(AppDbContext db)
        : base(db)
    {
    }
}
