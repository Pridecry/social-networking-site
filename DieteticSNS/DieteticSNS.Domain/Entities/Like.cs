using DieteticSNS.Domain.Entities.Base;

namespace DieteticSNS.Domain.Entities
{
    public abstract class Like : BaseTimeStampEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
