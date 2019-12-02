using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace DieteticSNS.Application.Models.Posts.Queries.GetPostList
{
    public class GetPostListQueryHandler : IRequestHandler<GetPostListQuery, PostListVm>
    {
        private readonly IConfiguration _configuration;

        public GetPostListQueryHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<PostListVm> Handle(GetPostListQuery request, CancellationToken cancellationToken)
        {
            var model = new PostListVm();

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DieteticSNSDatabase")))
            {
                var Posts = await connection.QueryAsync<PostDto>($@"
                    SELECT posts.Id, UserId, Title, Description, PhotoPath, CreatedAt, FirstName, LastName, AvatarPath
                    FROM dbo.Posts posts LEFT OUTER JOIN dbo.AspNetUsers users ON posts.UserId = users.Id
                    ORDER BY CreatedAt DESC;
                ");
                model.Posts = Posts.ToList();

                var Comments = await connection.QueryAsync<PostCommentDto>($@"
                    SELECT comments.Id, CreatedAt, UserId, Content, PostId, FirstName, LastName, AvatarPath
                    FROM dbo.Comments comments LEFT OUTER JOIN dbo.AspNetUsers users ON comments.UserId = users.Id
                    WHERE PostId IS NOT NULL;
                ");
                var commentList = Comments.ToList();

                var postLikes = await connection.QueryAsync<PostLikeDto>($@"
                    SELECT Id, UserId, PostId
                    FROM dbo.Likes
                    WHERE PostId IS NOT NULL;
                ");
                var postsLikeList = postLikes.ToList();

                var commentLikes = await connection.QueryAsync<CommentLikeDto>($@"
                    SELECT Id, UserId, CommentId
                    FROM dbo.Likes
                    WHERE CommentId IS NOT NULL;
                ");
                var commentsLikeList = commentLikes.ToList();

                foreach (var post in model.Posts)
                {
                    var postCommentList = commentList.Where(x => x.PostId == post.Id).ToList();
                    var postLikeList = postsLikeList.Where(x => x.PostId == post.Id).ToList();

                    post.PostComments.AddRange(postCommentList);
                    post.PostLikes.AddRange(postLikeList);

                    foreach (var comment in post.PostComments)
                    {
                        var commentLikeList = commentsLikeList.Where(x => x.CommentId == comment.Id).ToList();

                        comment.CommentLikes.AddRange(commentLikeList);
                    }
                }
            }

            return model;
        }
    }
}
