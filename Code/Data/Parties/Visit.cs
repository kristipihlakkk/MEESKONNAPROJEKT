using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Data;

    public class Visit
    {
        public Guid Id { get; set; }

        public DateTime VisitDate { get; set; }

        public string? Notes { get; set; }
    }

