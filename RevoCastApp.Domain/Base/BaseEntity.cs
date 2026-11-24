using System;
using System.Collections.Generic;
using System.Text;

namespace RevoCastApp.Domain.Base
{
    public abstract class BaseEntity : IBaseEntity
    {
        public int Id { get; set; }
    }
}
