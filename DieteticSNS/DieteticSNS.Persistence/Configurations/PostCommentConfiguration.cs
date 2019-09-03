using DieteticSNS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DieteticSNS.Persistence.Configurations
{
    internal class PostCommentConfiguration : IEntityTypeConfiguration<PostComment>
    {
        public void Configure(EntityTypeBuilder<PostComment> builder)
        {
            builder.HasOne(x => x.Post)
                .WithMany(x => x.PostComments)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
