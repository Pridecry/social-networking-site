namespace DieteticSNS.Application.Common.Interfaces
{
    public interface ICurrentUserService
    {
        string GetUserId();
        string GetUserFullName();
        int GetUserFollowersCount();
        int GetUserFollowingsCount();
        int GetUserPostsCount();
        string GetUserAvatarPath();
        bool HasAvatar();
    }
}
