using DieteticSNS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DieteticSNS.Persistence.Configurations
{
    internal class RecipeStarsConfiguration : IEntityTypeConfiguration<RecipeStars>
    {
        public void Configure(EntityTypeBuilder<RecipeStars> builder)
        {
            builder.HasOne(x => x.Recipe)
                .WithMany(x => x.RecipeStars)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
