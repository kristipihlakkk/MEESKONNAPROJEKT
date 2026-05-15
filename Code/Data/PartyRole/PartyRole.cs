using System;
using System.Collections.Generic;
using System.Text;
using Common;


namespace Gym.Data;

public abstract class PartyRole : BaseEntity
{
    public string RoleType { get; set; } = "";
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    public Guid PersonId { get; set; }
    public Person Person { get; set; } = null!;

    public bool IsActive()
    {
        var today = DateTime.Today;
        return StartDate <= today && (!EndDate.HasValue || EndDate >= today);
    }
}