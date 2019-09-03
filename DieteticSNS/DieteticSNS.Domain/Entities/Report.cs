using System;
using DieteticSNS.Domain.Entities.Base;

namespace DieteticSNS.Domain.Entities
{
    public class Report : BaseTimeStampEntity
    {
        public int AccuserId { get; set; }
        public User Accuser { get; set; }

        public string Content { get; set; }
    }
}
