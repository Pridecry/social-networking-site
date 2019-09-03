using DieteticSNS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DieteticSNS.Persistence.Configurations
{
    internal class RecipeCommentConfiguration : IEntityTypeConfiguration<RecipeComment>
    {
        public void Configure(EntityTypeBuilder<RecipeComment> builder)
        {
            builder.HasOne(x => x.Recipe)
                .WithMany(x => x.RecipeComments)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
