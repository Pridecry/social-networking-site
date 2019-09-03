using DieteticSNS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DieteticSNS.Persistence.Configurations
{
    internal class CommentReportConfiguration : IEntityTypeConfiguration<CommentReport>
    {
        public void Configure(EntityTypeBuilder<CommentReport> builder)
        {
            builder.HasOne(x => x.Comment)
                .WithMany(x => x.CommentReports)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
