using AutoMapper;
using DieteticSNS.Application.Models.Posts.Commands.CreatePost;
using DieteticSNS.Application.Models.Posts.Commands.UpdatePost;
using DieteticSNS.Application.Models.Posts.Queries.GetPostDetails;
using DieteticSNS.Domain.Entities;

namespace DieteticSNS.Application.Common.Mappings
{
    public class PostsProfile : Profile
    {
        public PostsProfile()
        {
            CreateMap<UpdatePostCommand, Post>();
            CreateMap<CreatePostCommand, Post>();

            CreateMap<PostDetailsVm, UpdatePostCommand>();
        }
    }
}
