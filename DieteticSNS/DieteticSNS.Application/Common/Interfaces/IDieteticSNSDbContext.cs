using System.Threading;
using System.Threading.Tasks;
using DieteticSNS.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DieteticSNS.Application.Common.Interfaces
{
    public interface IDieteticSNSDbContext
    {
        DbSet<Comment> Comments { get; set; }
        DbSet<CommentLike> CommentLikes { get; set; }
        DbSet<CommentReport> CommentReports { get; set; }
        DbSet<Country> Countries { get; set; }
        DbSet<Following> Followings { get; set; }
        DbSet<Like> Likes { get; set; }
        DbSet<Post> Posts { get; set; }
        DbSet<PostComment> PostComments { get; set; }
        DbSet<PostLike> PostLikes { get; set; }
        DbSet<PostReport> PostReports { get; set; }
        DbSet<Report> Reports { get; set; }
        DbSet<User> Users { get; set; }

        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        void DetachAll();
    }
}
