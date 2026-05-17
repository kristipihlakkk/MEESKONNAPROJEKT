using Common;

namespace Gym.Data;
//Default väärtused aga saab pühade jaoks muuta
public class OpenCloseTimes : BaseEntity {
    public DayOfWeek DayOfWeek { get; set; }
    public TimeOnly OpenFrom { get; set; } = new TimeOnly(6, 0);
    public TimeOnly OpenTo { get; set; } = new TimeOnly(22, 0);
    public bool IsClosed { get; set; }
}

public enum DayOfWeek {
    Monday,
    Tuesday,
    Wednesday,
    Thursday,
    Friday,
    Saturday,
    Sunday
}
