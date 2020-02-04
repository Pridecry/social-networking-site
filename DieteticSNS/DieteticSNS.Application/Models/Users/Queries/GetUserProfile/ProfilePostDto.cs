using System;
using System.Collections.Generic;

namespace DieteticSNS.Application.Models.Users.Queries.GetUserProfile
{
    public class ProfilePostDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PhotoPath { get; set; }
        public DateTime CreatedAt { get; set; }

        public List<ProfilePostLikeDto> PostLikes { get; set; } = new List<ProfilePostLikeDto>();
        public List<ProfilePostCommentDto> PostComments { get; set; } = new List<ProfilePostCommentDto>();
        public List<ProfilePostReportDto> PostReports { get; set; } = new List<ProfilePostReportDto>();
    }
}
