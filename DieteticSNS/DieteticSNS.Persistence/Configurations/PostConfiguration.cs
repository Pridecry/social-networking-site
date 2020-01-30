using DieteticSNS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DieteticSNS.Persistence.Configurations
{
    internal class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasMany(x => x.PostComments)
                .WithOne(x => x.Post)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.PostReports)
                .WithOne(x => x.Post)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.PostLikes)
                .WithOne(x => x.Post)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
