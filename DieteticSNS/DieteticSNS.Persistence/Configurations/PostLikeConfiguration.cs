using DieteticSNS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DieteticSNS.Persistence.Configurations
{
    internal class PostLikeConfiguration : IEntityTypeConfiguration<PostLike>
    {
        public void Configure(EntityTypeBuilder<PostLike> builder)
        {
            builder.HasOne(x => x.Post)
                .WithMany(x => x.PostLikes)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
