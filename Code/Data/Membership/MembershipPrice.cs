using System;
using System.Collections.Generic;
using System.Text;
using Common;

namespace Gym.Data.Membership
{
    public class MembershipPrice : BaseEntity
    {
        public string MembershipType { get; set; } = default!;

        public decimal Price { get; set; }

        public DateTime EffectiveFrom { get; set; } = DateTime.Now;

        public DateTime? EffectiveTo { get; set; }
    }
}
