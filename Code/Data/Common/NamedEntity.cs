namespace Common;

public abstract class NamedEntity : BaseEntity
{
    public virtual string Name { get; set; } = "";
}