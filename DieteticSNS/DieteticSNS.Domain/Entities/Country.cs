using System.Collections.Generic;
using DieteticSNS.Domain.Entities.Base;

namespace DieteticSNS.Domain.Entities
{
    public class Country : BaseEntity<int>
    {
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; private set; } = new HashSet<User>();
    }
}
