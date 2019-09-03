using DieteticSNS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DieteticSNS.Persistence.Configurations
{
    internal class CommentLikeConfiguration : IEntityTypeConfiguration<CommentLike>
    {
        public void Configure(EntityTypeBuilder<CommentLike> builder)
        {
            builder.HasOne(x => x.Comment)
                .WithMany(x => x.CommentLikes)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
