using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace DieteticSNS.Application.Models.Users.Queries.GetUserProfile
{
    public class GetUserProfileQueryHandler : IRequestHandler<GetUserProfileQuery, UserProfileVm>
    {
        private readonly IConfiguration _configuration;

        public GetUserProfileQueryHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<UserProfileVm> Handle(GetUserProfileQuery request, CancellationToken cancellationToken)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DieteticSNSDatabase")))
            {
                var model = await connection.QueryFirstOrDefaultAsync<UserProfileVm>($@"
                    SELECT Id, UserName, FirstName, LastName, BirthDate, Gender, AvatarPath, CountryId, 
	                    (SELECT COUNT(FollowerId)
	                    FROM Followings
	                    WHERE FollowerId = users.Id
	                    GROUP BY FollowerId) FollowingsCount
                    FROM AspNetUsers users
                    WHERE Id = { request.Id }
                ");

                var posts = await connection.QueryAsync<ProfilePostDto>($@"
                    SELECT Id, Title, Description, PhotoPath, CreatedAt
                    FROM Posts
                    WHERE UserId = { request.Id }
                    ORDER BY CreatedAt DESC;
                ");
                model.Posts = posts.ToList();

                if (posts.Count() != 0)
                {
                    string postIdSet = "(";
                    foreach (var post in model.Posts)
                    {
                        postIdSet += post.Id + ", ";
                    }
                    postIdSet = postIdSet.Remove(postIdSet.Length - 2) + ")";

                    var postLikes = await connection.QueryAsync<ProfilePostLikeDto>($@"
                        SELECT Likes.Id, UserId, PostId, FirstName, LastName, AvatarPath
                        FROM Likes LEFT OUTER JOIN AspNetUsers ON Likes.UserId = AspNetUsers.Id
                        WHERE Likes.PostId IN { postIdSet };
                    ");
                    var postsLikeList = postLikes.ToList();

                    var postReports = await connection.QueryAsync<ProfilePostReportDto>($@"
                        SELECT AccuserId, PostId
                        FROM Reports
                        WHERE PostId IN { postIdSet };
                    ");
                    var postReportsList = postReports.ToList();

                    var comments = await connection.QueryAsync<ProfilePostCommentDto>($@"
                        SELECT Comments.Id, CreatedAt, UserId, Content, PostId, FirstName, LastName, AvatarPath
                        FROM Comments LEFT OUTER JOIN AspNetUsers ON Comments.UserId = AspNetUsers.Id
                        WHERE PostId IN { postIdSet };
                    ");
                    var commentList = comments.ToList();

                    if (comments.Count() != 0)
                    {
                        string commentIdSet = "(";
                        foreach (var comment in commentList)
                        {
                            commentIdSet += comment.Id + ", ";
                        }
                        commentIdSet = commentIdSet.Remove(commentIdSet.Length - 2) + ")";

                        var commentLikes = await connection.QueryAsync<ProfileCommentLikeDto>($@"
                            SELECT Likes.Id, UserId, CommentId, FirstName, LastName, AvatarPath
                            FROM Likes LEFT OUTER JOIN AspNetUsers ON Likes.UserId = AspNetUsers.Id
                            WHERE Likes.CommentId IN { commentIdSet };
                        ");
                        var commentsLikeList = commentLikes.ToList();

                        var commentReports = await connection.QueryAsync<ProfileCommentReportDto>($@"
                            SELECT AccuserId, CommentId
                            FROM Reports
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
                    else
                    {
                        foreach (var post in model.Posts)
                        {
                            var postCommentList = commentList.Where(x => x.PostId == post.Id).ToList();
                            var postLikeList = postsLikeList.Where(x => x.PostId == post.Id).ToList();
                            var postReportList = postReportsList.Where(x => x.PostId == post.Id).ToList();

                            post.PostComments.AddRange(postCommentList);
                            post.PostLikes.AddRange(postLikeList);
                            post.PostReports.AddRange(postReportList);
                        }
                    }
                }

                return model;
            }
        }
    }
}
