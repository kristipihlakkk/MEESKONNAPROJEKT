using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Data;

    public class Trainer : Party
    {
        public string Specialisation { get; set; } = default!;
    
        public string? Bio { get; set; }
    }

