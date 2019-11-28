using AutoMapper;
using DieteticSNS.Application.Models.Comments.Commands.CreatePostComment;
using DieteticSNS.Domain.Entities;

namespace DieteticSNS.Application.Common.Mappings
{
    public class CommentsProfile : Profile
    {
        public CommentsProfile()
        {
            CreateMap<CreatePostCommentCommand, PostComment>();
        }
    }
}
