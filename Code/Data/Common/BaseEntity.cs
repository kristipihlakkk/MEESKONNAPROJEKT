using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public abstract class BaseEntity
    {
        public virtual Guid Id { get; set; }
    }
}
