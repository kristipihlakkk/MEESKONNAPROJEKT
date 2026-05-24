using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Data;

public sealed class Organisation : Party
{
    public string RegistrationNumber { get; set; } = "";
    public string? Website { get; set; }
}
