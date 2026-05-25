using Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Data;

public class Visit : BaseEntity
{
        public DateTime VisitDate { get; set; }

        public string? Notes { get; set; }
    }

