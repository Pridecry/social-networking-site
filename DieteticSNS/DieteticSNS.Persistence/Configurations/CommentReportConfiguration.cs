using DieteticSNS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DieteticSNS.Persistence.Configurations
{
    internal class CommentReportConfiguration : IEntityTypeConfiguration<CommentReport>
    {
        public void Configure(EntityTypeBuilder<CommentReport> builder)
        {
            builder.HasKey(x => new { x.CommentId, x.ReportId });
            builder.HasOne(x => x.Comment)
                .WithMany(x => x.CommentReports)
                .HasForeignKey(x => x.CommentId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Report)
                .WithMany(x => x.CommentReports)
                .HasForeignKey(x => x.ReportId);
        }
    }
}
