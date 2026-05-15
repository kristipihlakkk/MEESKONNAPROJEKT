using Gym.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;


namespace Gym.Infra;

public sealed class PersonsRepo : BaseRepo<Person>, IPersonsRepo
{
    public PersonsRepo(AppDbContext context) : base(context) { }
}
