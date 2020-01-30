using MediatR;

namespace DieteticSNS.Application.Models.Account.Commands.DeleteAccount
{
    public class DeleteAccountCommand : IRequest
    {
        public int Id { get; set; }
    }
}
