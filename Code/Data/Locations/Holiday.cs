using System;
using Common;

namespace Gym.Data;

public class Holiday : BaseEntity {
    public DateOnly Date { get; set; }
    public string Note { get; set; }    
    public TimeOnly? OpenFrom { get; set; }
    public TimeOnly? OpenTo { get; set; }
    public bool IsClosed { get; set; }
}
