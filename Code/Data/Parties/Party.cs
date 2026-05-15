using Common;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;


namespace Gym.Data;

public abstract class Party : BaseEntity
{
    public string? Notes { get; set; }
    public ICollection<Address> Addresses { get; set; } = [];
    public ICollection<ContactMethod> ContactMethods { get; set; } = [];
    public ICollection<PartyRole> Roles { get; set; } = [];
}
