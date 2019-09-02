using DieteticSNS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DieteticSNS.Persistence.Configurations
{
    internal class RecipeStarsConfiguration : IEntityTypeConfiguration<RecipeStars>
    {
        public void Configure(EntityTypeBuilder<RecipeStars> builder)
        {
            builder.HasKey(x => new { x.RecipeId, x.StarsId });
            builder.HasOne(x => x.Recipe)
                .WithMany(x => x.RecipeStars)
                .HasForeignKey(x => x.RecipeId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Stars)
                .WithMany(x => x.RecipeStars)
                .HasForeignKey(x => x.StarsId);
        }
    }
}
