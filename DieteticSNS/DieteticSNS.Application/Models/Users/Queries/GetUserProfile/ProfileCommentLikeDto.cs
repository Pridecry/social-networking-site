namespace DieteticSNS.Application.Models.Users.Queries.GetUserProfile
{
    public class ProfileCommentLikeDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CommentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AvatarPath { get; set; }
    }
}
