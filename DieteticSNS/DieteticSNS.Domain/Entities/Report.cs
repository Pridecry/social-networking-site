using DieteticSNS.Domain.Entities.Base;

namespace DieteticSNS.Domain.Entities
{
    public abstract class Report : BaseTimeStampEntity
    {
        public int AccuserId { get; set; }
        public User Accuser { get; set; }
    }
}
