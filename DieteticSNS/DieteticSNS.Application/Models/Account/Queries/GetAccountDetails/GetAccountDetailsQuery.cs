using MediatR;

namespace DieteticSNS.Application.Models.Account.Queries.GetUserDetails
{
    public class GetAccountDetailsQuery : IRequest<AccountDetailsVm>
    {
        public int Id { get; set; }
    }
}
