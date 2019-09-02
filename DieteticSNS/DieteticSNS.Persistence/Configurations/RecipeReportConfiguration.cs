using DieteticSNS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DieteticSNS.Persistence.Configurations
{
    internal class RecipeReportConfiguration : IEntityTypeConfiguration<RecipeReport>
    {
        public void Configure(EntityTypeBuilder<RecipeReport> builder)
        {
            builder.HasKey(x => new { x.RecipeId, x.ReportId });
            builder.HasOne(x => x.Recipe)
                .WithMany(x => x.RecipeReports)
                .HasForeignKey(x => x.RecipeId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Report)
                .WithMany(x => x.RecipeReports)
                .HasForeignKey(x => x.ReportId);
        }
    }
}
