using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Common
{
    public abstract class BaseEntity
    {
        public virtual Guid Id { get; set; } = Guid.NewGuid();
        [Timestamp] public virtual byte[] Timestamp { get; set; } = Array.Empty<byte>();
        public virtual DateTime ValidFrom { get; set; }
        public virtual DateTime ValidTo { get; set; }
    }
}
