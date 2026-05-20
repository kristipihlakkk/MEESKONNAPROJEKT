using System;
using System.Collections.Generic;
using System.Text;
using Gym.Data;

namespace Gym.Services
{
    public interface IMembershipService
    {
        Membership CreateSubscription(Guid memberId, MembershipType membershipType, decimal price, DateTime? startDate = null);

        Membership Renew(Membership membership, MembershipType membershipType, decimal price);

        void Cancel(Membership membership);
    }
}
