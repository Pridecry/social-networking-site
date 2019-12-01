using System;
using System.Collections.Generic;

namespace DieteticSNS.Application.Models.Posts.Queries.GetPostList
{
    public class PostDto
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

        public List<PostLikeDto> PostLikes { get; set; } = new List<PostLikeDto>();
        public List<PostCommentDto> PostComments { get; set; } = new List<PostCommentDto>();
    }
}
