using DieteticSNS.Domain.Entities.Base;

namespace DieteticSNS.Domain.Entities
{
    public class Stars : BaseTimeStampEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int Amount { get; set; }
    }
}
