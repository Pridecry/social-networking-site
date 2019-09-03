using System;
using DieteticSNS.Domain.Entities.Base;

namespace DieteticSNS.Domain.Entities
{
    public class Following : TimeStampEntity
    {
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public int FollowerId { get; set; }
        public virtual User Follower { get; set; }
    }
}
