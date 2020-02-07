using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DieteticSNS.Application.Common.Interfaces;
using DieteticSNS.Domain.Entities;
using DieteticSNS.Domain.Entities.Base;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DieteticSNS.Persistence
{
    public class DieteticSNSDbContext : IdentityDbContext<User, IdentityRole<int>, int>, IDieteticSNSDbContext
    {
        public DieteticSNSDbContext(DbContextOptions<DieteticSNSDbContext> options) : base(options)
        {
        }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<CommentLike> CommentLikes { get; set; }
        public DbSet<CommentReport> CommentReports { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Following> Followings { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostComment> PostComments { get; set; }
        public DbSet<PostLike> PostLikes { get; set; }
        public DbSet<PostReport> PostReports { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<UserNotificationSettings> UserNotificationSettings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DieteticSNSDbContext).Assembly);
        }

        public override int SaveChanges()
        {
            AddTimestamps();

            return base.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return SaveChangesAsync(new CancellationToken());
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            AddTimestamps();

            return await base.SaveChangesAsync(cancellationToken);
        }

        private void AddTimestamps()
        {
            var entries = ChangeTracker.Entries().Where(x => x.State == EntityState.Modified);

            foreach (var entry in entries)
            {
                if (entry.Entity is BaseTimeStampEntity baseTimeStamp)
                {
                    var now = DateTime.UtcNow;

                    switch (entry.State)
                    {
                        case EntityState.Added:
                            //baseTimeStamp.Id = Guid.NewGuid();    ///Check if its correct?
                            baseTimeStamp.CreatedAt = now;
                            baseTimeStamp.UpdatedAt = now;
                            break;

                        case EntityState.Modified:
                            baseTimeStamp.UpdatedAt = now;
                            break;

                        case EntityState.Detached:
                            break;

                        case EntityState.Unchanged:
                            break;

                        case EntityState.Deleted:
                            break;

                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
                else if (entry.Entity is TimeStampEntity timeStamp)
                {
                    var now = DateTime.UtcNow;

                    switch (entry.State)
                    {
                        case EntityState.Added:
                            timeStamp.CreatedAt = now;
                            timeStamp.UpdatedAt = now;
                            break;

                        case EntityState.Modified:
                            timeStamp.UpdatedAt = now;
                            break;

                        case EntityState.Detached:
                            break;

                        case EntityState.Unchanged:
                            break;

                        case EntityState.Deleted:
                            break;

                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }

            }
        }

        /// <summary>
        /// Detaches all of the objects that have been added to the ChangeTracker.
        /// </summary>
        public void DetachAll()
        {
            foreach (var dbEntityEntry in ChangeTracker.Entries().ToArray())
            {
                if (dbEntityEntry.Entity != null)
                {
                    dbEntityEntry.State = EntityState.Detached;
                }
            }
        }
    }
}
