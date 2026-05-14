using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Gym.Data;

public class GymMember : Party
{
    public Membership? Membership { get; set; }

    public List<Visit> Visits { get; set; } = new();

    public int VisitCount => Visits.Count;

    public DateTime? LastVisitDate =>
        Visits.OrderByDescending(v => v.VisitDate)
              .FirstOrDefault()?.VisitDate;
}