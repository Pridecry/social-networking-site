namespace DieteticSNS.Application.Models.Account.Queries.GetUserNotificationSettings
{
    public class UserNotificationSettingsVm
    {
        public bool PostComments { get; set; }
        public bool PostLikes { get; set; }
        public bool CommentLikes { get; set; }
        public bool UserFollowings { get; set; }
        public bool UserUnfollowings { get; set; }
    }
}
