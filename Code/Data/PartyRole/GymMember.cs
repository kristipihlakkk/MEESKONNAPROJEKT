using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Common;
using Gym.Data.Membership;

namespace Gym.Data;

public class GymMember : PartyRole
{
    public MembershipType? Membership { get; set; }

    public List<Visit> Visits { get; set; } = new();

    public int VisitCount => Visits.Count;

    public DateTime? LastVisitDate =>
        Visits.OrderByDescending(v => v.VisitDate)
              .FirstOrDefault()?.VisitDate;
}