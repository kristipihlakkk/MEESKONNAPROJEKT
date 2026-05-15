using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Infra;
public sealed class SeedData(AppDbContext db, int recCnt = 20)
    {
        public async Task Seed()
        {
        }
    }
