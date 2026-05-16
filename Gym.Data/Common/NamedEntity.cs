namespace Gym.Data.Common;

// Martin "Clean Code" raamatus on reegel, etkui mitmes klassis on sama väli, ss tuleks tõsta see ühisesse baasklassi
//Seda nimetatakse "Extract Superclass".
// +Movie projekti paraleel, tehtud Abc.Data.Common.NamedEntity eeskujul
public abstract class NamedEntity : BaseEntity
{
    public virtual string Name { get; set; } = string.Empty;
}