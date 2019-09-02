using DieteticSNS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DieteticSNS.Persistence.Configurations
{
    internal class CommentLikeConfiguration : IEntityTypeConfiguration<CommentLike>
    {
        public void Configure(EntityTypeBuilder<CommentLike> builder)
        {
            builder.HasKey(x => new { x.CommentId, x.LikeId });
            builder.HasOne(x => x.Comment)
                .WithMany(x => x.CommentLikes)
                .HasForeignKey(x => x.CommentId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Like)
                .WithMany(x => x.CommentLikes)
                .HasForeignKey(x => x.LikeId);
        }
    }
}
