using DieteticSNS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DieteticSNS.Persistence.Configurations
{
    internal class PostReportConfiguration : IEntityTypeConfiguration<PostReport>
    {
        public void Configure(EntityTypeBuilder<PostReport> builder)
        {
            builder.HasKey(x => new { x.PostId, x.ReportId });
            builder.HasOne(x => x.Post)
                .WithMany(x => x.PostReports)
                .HasForeignKey(x => x.PostId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Report)
                .WithMany(x => x.PostReports)
                .HasForeignKey(x => x.ReportId);
        }
    }
}
