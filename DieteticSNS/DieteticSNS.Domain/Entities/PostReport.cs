using System;

namespace DieteticSNS.Domain.Entities
{
    public class PostReport : Report
    {
        public int PostId { get; set; }
        public virtual Post Post { get; set; }
    }
}
