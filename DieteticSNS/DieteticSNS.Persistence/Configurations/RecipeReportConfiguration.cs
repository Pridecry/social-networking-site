using DieteticSNS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DieteticSNS.Persistence.Configurations
{
    internal class RecipeReportConfiguration : IEntityTypeConfiguration<RecipeReport>
    {
        public void Configure(EntityTypeBuilder<RecipeReport> builder)
        {
            builder.HasOne(x => x.Recipe)
                .WithMany(x => x.RecipeReports)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
