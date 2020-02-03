using System;

namespace DieteticSNS.Application.Models.Posts.Queries.GetMinifiedPostList
{
    public class MinifiedPostDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PhotoPath { get; set; }
        public DateTime CreatedAt { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AvatarPath { get; set; }
        public int LikeCount { get; set; }
    }
}
