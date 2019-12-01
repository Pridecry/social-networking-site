using MediatR;

namespace DieteticSNS.Application.Models.Likes.Commands.DeleteLike
{
    public class DeleteLikeCommand : IRequest
    {
        public int Id { get; set; }
    }
}
