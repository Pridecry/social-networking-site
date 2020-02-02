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
                var posts = await connection.QueryAsync<PostDto>($@"
                    SELECT posts.Id, UserId, Title, Description, PhotoPath, CreatedAt, FirstName, LastName, AvatarPath
                    FROM dbo.Posts posts LEFT OUTER JOIN dbo.AspNetUsers users ON posts.UserId = users.Id
                    WHERE SYSDATETIME() > IIF(LockoutEnd IS NULL, DATEADD(minute, -1, SYSDATETIME()), LockoutEnd)
                    ORDER BY CreatedAt DESC;
                ");
                model.Posts = posts.ToList();

                string postIdSet = "(";
                foreach (var post in model.Posts)
                {
                    postIdSet += post.Id + ", ";
                }
                postIdSet = postIdSet.Remove(postIdSet.Length - 2) + ")";

                var Comments = await connection.QueryAsync<PostCommentDto>($@"
                    SELECT comments.Id, CreatedAt, UserId, Content, PostId, FirstName, LastName, AvatarPath
                    FROM dbo.Comments comments LEFT OUTER JOIN dbo.AspNetUsers users ON comments.UserId = users.Id
                    WHERE PostId IN { postIdSet };
                ");
                var commentList = Comments.ToList();

                string commentIdSet = "(";
                foreach (var comment in commentList)
                {
                    commentIdSet += comment.Id + ", ";
                }
                commentIdSet = commentIdSet.Remove(commentIdSet.Length - 2) + ")";

                var postLikes = await connection.QueryAsync<PostLikeDto>($@"
                    SELECT Id, UserId, PostId
                    FROM dbo.Likes
                    WHERE PostId IN { postIdSet };
                ");
                var postsLikeList = postLikes.ToList();

                var commentLikes = await connection.QueryAsync<CommentLikeDto>($@"
                    SELECT Id, UserId, CommentId
                    FROM dbo.Likes
                    WHERE CommentId IN { commentIdSet };
                ");
                var commentsLikeList = commentLikes.ToList();

                var postReports = await connection.QueryAsync<PostReportDto>($@"
                    SELECT AccuserId, PostId
                    FROM dbo.Reports
                    WHERE PostId IN { postIdSet };
                ");
                var postReportsList = postReports.ToList();

                var commentReports = await connection.QueryAsync<CommentReportDto>($@"
                    SELECT AccuserId, CommentId
                    FROM dbo.Reports
                    WHERE CommentId IN { commentIdSet };
                ");
                var commentReportsList = commentReports.ToList();

                foreach (var post in model.Posts)
                {
                    var postCommentList = commentList.Where(x => x.PostId == post.Id).ToList();
                    var postLikeList = postsLikeList.Where(x => x.PostId == post.Id).ToList();
                    var postReportList = postReportsList.Where(x => x.PostId == post.Id).ToList();

                    post.PostComments.AddRange(postCommentList);
                    post.PostLikes.AddRange(postLikeList);
                    post.PostReports.AddRange(postReportList);

                    foreach (var comment in post.PostComments)
                    {
                        var commentLikeList = commentsLikeList.Where(x => x.CommentId == comment.Id).ToList();
                        var commentReportList = commentReportsList.Where(x => x.CommentId == comment.Id).ToList();

                        comment.CommentLikes.AddRange(commentLikeList);
                        comment.CommentReports.AddRange(commentReportList);
                    }
                }
            }

            return model;
        }
    }
}
