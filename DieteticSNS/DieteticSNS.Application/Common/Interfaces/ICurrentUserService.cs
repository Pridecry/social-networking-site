namespace DieteticSNS.Application.Common.Interfaces
{
    public interface ICurrentUserService
    {
        string GetUserId();
        string GetUserFullName();
        int GetUserFollowersCount();
        int GetUserFollowingsCount();
        int GetUserPostsCount();
        int GetUserRecipesCount();
        string GetUserAvatarPath();
    }
}
