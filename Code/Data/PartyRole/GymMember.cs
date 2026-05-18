using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Gym.Data;
using Common;

namespace Gym.Data;

public class GymMember : PartyRole
{
    public Membership? Membership { get; set; }

    public List<Visit> Visits { get; set; } = new();

    public int VisitCount => Visits.Count;

    public DateTime? LastVisitDate =>
        Visits.OrderByDescending(v => v.VisitDate)
              .FirstOrDefault()?.VisitDate;
}