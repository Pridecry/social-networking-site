using DieteticSNS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DieteticSNS.Persistence.Configurations
{
    internal class RecipeCommentConfiguration : IEntityTypeConfiguration<RecipeComment>
    {
        public void Configure(EntityTypeBuilder<RecipeComment> builder)
        {
            builder.HasKey(x => new { x.RecipeId, x.CommentId });
            builder.HasOne(x => x.Recipe)
                .WithMany(x => x.RecipeComments)
                .HasForeignKey(x => x.RecipeId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Comment)
                .WithMany(x => x.RecipeComments)
                .HasForeignKey(x => x.CommentId);
        }
    }
}
