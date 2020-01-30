using DieteticSNS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DieteticSNS.Persistence.Configurations
{
    internal class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasMany(x => x.CommentLikes)
                .WithOne(x => x.Comment)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.CommentReports)
                .WithOne(x => x.Comment)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
