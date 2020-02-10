using DieteticSNS.Domain.Entities.Base;
using DieteticSNS.Domain.Enumerations;

namespace DieteticSNS.Domain.Entities
{
    public class Notification : BaseTimeStampEntity
    {
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public int RecipientId { get; set; }
        public virtual User Recipient { get; set; }

        public bool IsRead { get; set; }
        public NotificationType NotificationType { get; set; }
    }
}
