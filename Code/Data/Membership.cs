using Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abc.Data;
public class Membership : BaseEntity
{
         public Guid Id { get; set; }

        public string MembershipType { get; set; } = default!;

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool IsActive()
        {
            return DateTime.Now >= StartDate &&
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
