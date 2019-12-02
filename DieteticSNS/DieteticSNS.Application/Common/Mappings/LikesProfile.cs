using AutoMapper;
using DieteticSNS.Application.Models.Likes.Commands.CreateCommentLike;
using DieteticSNS.Application.Models.Likes.Commands.CreatePostLike;
using DieteticSNS.Domain.Entities;

namespace DieteticSNS.Application.Common.Mappings
{
    public class LikesProfile : Profile
    {
        public LikesProfile()
        {
            CreateMap<CreatePostLikeCommand, PostLike>();
            CreateMap<CreateCommentLikeCommand, CommentLike>();
        }
    }
}
