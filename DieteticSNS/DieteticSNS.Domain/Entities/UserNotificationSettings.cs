namespace DieteticSNS.Domain.Entities
{
    public class UserNotificationSettings
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

        public bool PostComments { get; set; } = true;
        public bool PostLikes { get; set; } = true;
        public bool CommentLikes { get; set; } = true;
        public bool UserFollowings { get; set; } = true;
        public bool UserUnfollowings { get; set; } = true;
    }
}
