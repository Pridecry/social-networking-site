using System;

namespace DieteticSNS.Application.Models.Reports.Queries.GetReportList
{
    public class CommentReportDto
    {
        public int Count { get; set; }
        public int CommentId { get; set; }
        public DateTime CreatedAt { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AvatarPath { get; set; }
    }
}
