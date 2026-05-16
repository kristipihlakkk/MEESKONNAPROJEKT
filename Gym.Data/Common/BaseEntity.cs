namespace Gym.Data.Common;

//Clean Code raamatust Id ja ajatemplid ühes kohas, mitte igas klassis eraldi
public abstract class BaseEntity
{
    public virtual Guid Id { get; set; } = Guid.NewGuid();
    public virtual DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public virtual DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public virtual byte[] Timestamp { get; set; } = [];
}