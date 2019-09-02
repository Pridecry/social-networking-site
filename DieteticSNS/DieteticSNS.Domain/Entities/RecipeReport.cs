using System;

namespace DieteticSNS.Domain.Entities
{
    public class RecipeReport
    {
        public Guid RecipeId { get; set; }
        public virtual Recipe Recipe { get; set; }

        public Guid ReportId { get; set; }
        public virtual Report Report { get; set; }
    }
}
