using System;

namespace DieteticSNS.Domain.Entities
{
    public class RecipeReport : Report
    {
        public Guid RecipeId { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}
