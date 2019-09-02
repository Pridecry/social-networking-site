using System;
using System.Collections.Generic;
using DieteticSNS.Domain.Entities.Base;

namespace DieteticSNS.Domain.Entities
{
    public class Stars : BaseTimeStampEntity
    {
        public Guid UserId { get; set; }
        public User User { get; set; }

        public int Amount { get; set; }

        public virtual ICollection<RecipeStars> RecipeStars { get; set; } = new HashSet<RecipeStars>();
    }
}
