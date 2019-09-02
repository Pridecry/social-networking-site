﻿using System;
using System.Collections.Generic;
using DieteticSNS.Domain.Entities.Base;

namespace DieteticSNS.Domain.Entities
{
    public class Country : BaseEntity<Guid>
    {
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; } = new HashSet<User>();
    }
}
