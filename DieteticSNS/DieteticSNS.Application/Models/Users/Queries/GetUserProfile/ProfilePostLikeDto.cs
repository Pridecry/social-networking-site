namespace DieteticSNS.Application.Models.Users.Queries.GetUserProfile
{
    public class ProfilePostLikeDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AvatarPath { get; set; }
    }
}
