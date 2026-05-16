using Gym.Data.Common;

namespace Gym.Data;

// Arlowi PartyRole arhetüüp: "roll mida isik mängib", GymMember ja Trainer pärivad sellest
// Evans DDD: IsActive() on äriloogika meetod, et kuulub KLASSI mitte controllerisse
public abstract class PartyRole : BaseEntity
{
    public Guid PartyId { get; set; }
    public virtual Person Party { get; set; }
    public DateTime? RoleStartDate { get; set; } = DateTime.UtcNow;
    public DateTime? RoleEndDate { get; set; }

    public bool IsActive()
        => RoleStartDate <= DateTime.UtcNow
        && (RoleEndDate is null || RoleEndDate >= DateTime.UtcNow);
}