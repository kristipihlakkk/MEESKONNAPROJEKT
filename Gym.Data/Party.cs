using Gym.Data.Common;

namespace Gym.Data;

// Arlow Enterprise Patterns and MDA raamatust
// Party arhetüüp: "üks isik, mitu rolli", uks isik saab olla nii GymMember kui Trainer
// Movie paralleel: nii nagu Movie pärib Movie : NamedEntity, on Party : NamedEntity
public abstract class Party : NamedEntity
{
    public virtual ICollection<PartyRole> Roles { get; set; }
        = new List<PartyRole>();
}