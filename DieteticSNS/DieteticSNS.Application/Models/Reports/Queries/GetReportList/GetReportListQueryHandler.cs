using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using DieteticSNS.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace DieteticSNS.Application.Models.Reports.Queries.GetReportList
{
    public class GetReportListQueryHandler : IRequestHandler<GetReportListQuery, ReportListVm>
    {
        private readonly IConfiguration _configuration;

        public GetReportListQueryHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<ReportListVm> Handle(GetReportListQuery request, CancellationToken cancellationToken)
        {
            var model = new ReportListVm();

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DieteticSNSDatabase")))
            {
                var commentReports = await connection.QueryAsync<CommentReportDto>($@"
                    SELECT COUNT(CommentId) Count, CommentId, Comments.CreatedAt CreatedAt, UserId, Content, FirstName, LastName, AvatarPath
                    FROM Reports LEFT OUTER JOIN Comments ON Reports.CommentId = Comments.Id LEFT OUTER JOIN AspNetUsers ON Comments.UserId = AspNetUsers.Id
                    WHERE Reports.Discriminator = '{ nameof(CommentReport) }'
                    AND SYSDATETIME() > IIF(LockoutEnd IS NULL, DATEADD(minute, -1, SYSDATETIME()), LockoutEnd)
                    GROUP BY CommentId, Comments.CreatedAt, UserId, Content, FirstName, LastName, AvatarPath
                    ORDER BY COUNT(CommentId) DESC, CreatedAt;
                ");
                model.CommentReports = commentReports.ToList();

                var postReports = await connection.QueryAsync<PostReportDto>($@"
                    SELECT COUNT(PostId) Count, PostId, Posts.CreatedAt CreatedAt, UserId, Title, Description, PhotoPath, FirstName, LastName, AvatarPath
                    FROM Reports LEFT OUTER JOIN Posts ON Reports.PostId = Posts.Id LEFT OUTER JOIN AspNetUsers ON Posts.UserId = AspNetUsers.Id
                    WHERE Discriminator = '{ nameof(PostReport) }'
                    AND SYSDATETIME() > IIF(LockoutEnd IS NULL, DATEADD(minute, -1, SYSDATETIME()), LockoutEnd)
                    GROUP BY PostId, Posts.CreatedAt, UserId, Title, Description, PhotoPath, FirstName, LastName, AvatarPath
                    ORDER BY COUNT(PostId) DESC, CreatedAt;
                ");
                model.PostReports = postReports.ToList();
            }

            return model;
        }
    }
}
