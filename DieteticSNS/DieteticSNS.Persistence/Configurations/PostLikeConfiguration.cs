using DieteticSNS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DieteticSNS.Persistence.Configurations
{
    internal class PostLikeConfiguration : IEntityTypeConfiguration<PostLike>
    {
        public void Configure(EntityTypeBuilder<PostLike> builder)
        {
            builder.HasKey(x => new { x.PostId, x.LikeId });
            builder.HasOne(x => x.Post)
                .WithMany(x => x.PostLikes)
                .HasForeignKey(x => x.PostId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Like)
                .WithMany(x => x.PostLikes)
                .HasForeignKey(x => x.LikeId);
        }
    }
}
