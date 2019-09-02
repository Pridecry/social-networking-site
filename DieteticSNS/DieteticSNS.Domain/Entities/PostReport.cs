using System;

namespace DieteticSNS.Domain.Entities
{
    public class PostReport
    {
        public Guid PostId { get; set; }
        public virtual Post Post { get; set; }

        public Guid ReportId { get; set; }
        public virtual Report Report { get; set; }
    }
}
