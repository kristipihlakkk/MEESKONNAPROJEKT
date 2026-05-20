using Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Data.Membership;

public class Membership : BaseEntity
{
    public Guid MemberId { get; set; }

    public string MembershipType { get; set; } = default!;

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public decimal PricePaid { get; set; }

    public MembershipStatus Status { get; set; } = MembershipStatus.Pending;

    public bool IsActive()
    {
        return Status == MembershipStatus.Active &&
               DateTime.Now >= StartDate &&
               DateTime.Now <= EndDate;
    }

    public int DaysRemaining()
    {
        if (!IsActive())
        {
            return 0;
        }

        return (EndDate - DateTime.Now).Days;
    }
}
