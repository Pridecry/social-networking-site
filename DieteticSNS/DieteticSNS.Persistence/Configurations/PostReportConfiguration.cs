using DieteticSNS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DieteticSNS.Persistence.Configurations
{
    internal class PostReportConfiguration : IEntityTypeConfiguration<PostReport>
    {
        public void Configure(EntityTypeBuilder<PostReport> builder)
        {
            builder.HasOne(x => x.Post)
                .WithMany(x => x.PostReports)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
