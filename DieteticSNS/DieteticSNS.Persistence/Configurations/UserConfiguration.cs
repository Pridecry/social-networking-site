using DieteticSNS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DieteticSNS.Persistence.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasOne(x => x.Country)
                .WithMany(x => x.Users)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(x => x.Followings)
                .WithOne(x => x.Follower)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Followers)
                .WithOne(x => x.User)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Posts)
                .WithOne(x => x.User)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Comments)
                .WithOne(x => x.User)
                .OnDelete(DeleteBehavior.Restrict); 

            builder.HasMany(x => x.Reports)
                .WithOne(x => x.Accuser)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Likes)
                .WithOne(x => x.User)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
