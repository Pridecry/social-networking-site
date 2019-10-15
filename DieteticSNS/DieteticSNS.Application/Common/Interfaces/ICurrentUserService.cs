namespace DieteticSNS.Application.Common.Interfaces
{
    public interface ICurrentUserService
    {
        string GetUserId();
        string GetUserFullName();
    }
}
