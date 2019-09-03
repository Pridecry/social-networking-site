using DieteticSNS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DieteticSNS.Persistence.Configurations
{
    internal class FollowingConfiguration : IEntityTypeConfiguration<Following>
    {
        public void Configure(EntityTypeBuilder<Following> builder)
        {
            builder.HasKey(x => new { x.UserId, x.FollowerId });
            builder.HasOne(x => x.User)
                .WithMany(x => x.Followers)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Follower)
                .WithMany(x => x.Followings)
                .HasForeignKey(x => x.FollowerId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
