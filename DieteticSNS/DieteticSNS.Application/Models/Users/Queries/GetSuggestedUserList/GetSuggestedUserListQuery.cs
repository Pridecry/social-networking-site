using MediatR;

namespace DieteticSNS.Application.Models.Users.Queries.GetSuggestedUserList
{
    public class GetSuggestedUserListQuery : IRequest<SuggestedUserListVm>
    {
    }
}
