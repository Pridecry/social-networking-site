using DieteticSNS.Domain.Entities.Base;

namespace DieteticSNS.Domain.Entities
{
    public class Notification : TimeStampEntity
    {
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public int RecipientId { get; set; }
        public virtual User Recipient { get; set; }

        public bool IsRead { get; set; }
    }
}
