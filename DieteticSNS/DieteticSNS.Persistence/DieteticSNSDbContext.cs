using DieteticSNS.Application.Interfaces;
using DieteticSNS.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DieteticSNS.Persistence
{
    public class DieteticSNSDbContext : DbContext, IDieteticSNSDbContext
    {
        public DieteticSNSDbContext(DbContextOptions<DieteticSNSDbContext> options) : base(options)
        {

        }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<CommentLike> CommentLikes { get; set; }
        public DbSet<CommentReport> CommentReports { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Following> Followings { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostComment> PostComments { get; set; }
        public DbSet<PostLike> PostLikes { get; set; }
        public DbSet<PostReport> PostReports { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeComment> RecipeComments { get; set; }
        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }
        public DbSet<RecipeReport> RecipeReports { get; set; }
        public DbSet<RecipeStars> RecipeStars { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Stars> Stars { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DieteticSNSDbContext).Assembly);
        }
    }
}
