using System;
using System.Collections.Generic;
using System.Text;
using Gym.Data;

namespace Gym.Services
{
    public class MembershipService : IMembershipService
    {
        // Create a subscription for a member based on a MembershipType
        public Membership CreateSubscription(Guid memberId, MembershipType membershipType, decimal price, DateTime? startDate = null)
        {
            var start = startDate ?? DateTime.Now;
            var membership = new Membership
            {
                MemberId = memberId,
                MembershipType = membershipType?.Name ?? "",
                StartDate = start,
                EndDate = start.AddDays(membershipType?.DurationDays ?? 30),
                PricePaid = price,
                Status = MembershipStatus.Active
            };

            return membership;
        }

        // Renew extends the membership by the membershipType duration starting from the current EndDate if active
        public Membership Renew(Membership membership, MembershipType membershipType, decimal price)
        {
            if (membership == null) throw new ArgumentNullException(nameof(membership));
            if (membershipType == null) throw new ArgumentNullException(nameof(membershipType));

            var addDays = membershipType.DurationDays > 0 ? membershipType.DurationDays : 30;

            if (membership.Status == MembershipStatus.Active && membership.EndDate > DateTime.Now)
            {
                membership.EndDate = membership.EndDate.AddDays(addDays);
            }
            else
            {
                // expired or not active -> start from today
                membership.StartDate = DateTime.Now;
                membership.EndDate = DateTime.Now.AddDays(addDays);
                membership.Status = MembershipStatus.Active;
            }

            membership.PricePaid = price;

            return membership;
        }

        public void Cancel(Membership membership)
        {
            if (membership == null) throw new ArgumentNullException(nameof(membership));

            membership.Status = MembershipStatus.Cancelled;
            membership.EndDate = DateTime.Now;
        }
    }
}
