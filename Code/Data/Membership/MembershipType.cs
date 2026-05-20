using System;
using System.Collections.Generic;
using System.Text;
using Common;

namespace Gym.Data.Membership
{
    public class MembershipType : Common.NamedEntity
    {
        public int DurationDays { get; set; }
        public decimal Price { get; set; }
        public bool IsAnnual => DurationDays >= 365;
        public bool IsMonthly => DurationDays >= 28 && DurationDays <= 31;
        
        public string MembershipTypeName
        {
            get
            {
                if (IsMonthly)
                {
                    return "MonthlyMembership";
                }

                if (IsAnnual)
                {
                    return "AnnualMembership";
                }

                return "Membership";
            }
        }
    }
}
