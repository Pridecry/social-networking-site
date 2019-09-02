using System;

namespace DieteticSNS.Domain.Entities.Base
{
    public abstract class BaseTimeStampEntity : BaseEntity<Guid>
    {
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
