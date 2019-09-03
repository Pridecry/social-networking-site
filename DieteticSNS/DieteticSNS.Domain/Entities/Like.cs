using System;
using DieteticSNS.Domain.Entities.Base;

namespace DieteticSNS.Domain.Entities
{
    public class Like : BaseTimeStampEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
