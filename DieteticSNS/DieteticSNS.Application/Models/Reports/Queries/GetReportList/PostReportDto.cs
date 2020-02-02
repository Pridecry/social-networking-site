using System;

namespace DieteticSNS.Application.Models.Reports.Queries.GetReportList
{
    public class PostReportDto
    {
        public int Count { get; set; }
        public int PostId { get; set; }
        public DateTime CreatedAt { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PhotoPath { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AvatarPath { get; set; }
    }
}
