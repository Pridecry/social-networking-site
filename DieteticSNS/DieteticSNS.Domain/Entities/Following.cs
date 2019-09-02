using System;
using DieteticSNS.Domain.Entities.Base;

namespace DieteticSNS.Domain.Entities
{
    public class Following : TimeStampEntity
    {
        public Guid UserId { get; set; }
        public virtual User User { get; set; }

        public Guid FollowerId { get; set; }
        public virtual User Follower { get; set; }
    }
}
