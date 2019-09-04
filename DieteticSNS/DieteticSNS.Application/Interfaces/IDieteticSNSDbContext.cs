using System.Threading;
using System.Threading.Tasks;
using DieteticSNS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DieteticSNS.Application.Interfaces
{
    public interface IDieteticSNSDbContext
    {
        DbSet<Comment> Comments { get; set; }
        DbSet<CommentLike> CommentLikes { get; set; }
        DbSet<CommentReport> CommentReports { get; set; }
        DbSet<Country> Countries { get; set; }
        DbSet<Following> Followings { get; set; }
        DbSet<Ingredient> Ingredients { get; set; }
        DbSet<Like> Likes { get; set; }
        DbSet<Post> Posts { get; set; }
        DbSet<PostComment> PostComments { get; set; }
        DbSet<PostLike> PostLikes { get; set; }
        DbSet<PostReport> PostReports { get; set; }
        DbSet<Recipe> Recipes { get; set; }
        DbSet<RecipeComment> RecipeComments { get; set; }
        DbSet<RecipeIngredient> RecipeIngredients { get; set; }
        DbSet<RecipeReport> RecipeReports { get; set; }
        DbSet<RecipeStars> RecipeStars { get; set; }
        DbSet<Report> Reports { get; set; }
        DbSet<Stars> Stars { get; set; }
        DbSet<User> Users { get; set; }

        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        void DetachAll();

        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
