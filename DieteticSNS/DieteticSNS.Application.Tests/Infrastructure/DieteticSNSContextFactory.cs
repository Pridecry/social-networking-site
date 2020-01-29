using System;
using DieteticSNS.Domain.Entities;
using DieteticSNS.Domain.Enumerations;
using DieteticSNS.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DieteticSNS.Application.Tests.Infrastructure
{
    public class DieteticSNSContextFactory
    {
        public static DieteticSNSDbContext Create()
        {
            var options = new DbContextOptionsBuilder<DieteticSNSDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new DieteticSNSDbContext(options);

            context.Database.EnsureCreated();

            //context.Comments.AddRange(AddCommentsToDatabase());
            context.CommentLikes.AddRange(AddCommentLikesToDatabase());
            context.CommentReports.AddRange(AddCommentReportsToDatabase());
            context.Countries.AddRange(AddCountriesToDatabase());
            context.Followings.AddRange(AddFollowingsToDatabase());
            //context.Likes.AddRange(AddLikesToDatabase());
            context.Posts.AddRange(AddPostsToDatabase());
            context.PostComments.AddRange(AddPostCommentsToDatabase());
            context.PostLikes.AddRange(AddPostLikesToDatabase());
            context.PostReports.AddRange(AddPostReportsToDatabase());
            //context.Reports.AddRange(AddReportsToDatabase());
            context.Users.AddRange(AddUsersToDatabase());

            context.SaveChanges();

            return context;
        }

        public static void Destroy(DieteticSNSDbContext context)
        {
            context.Database.EnsureDeleted();

            context.Dispose();
        }

        //private static Comment[] AddCommentsToDatabase()
        //{
        //    int commentsCount = 10;
        //    var comments = new Comment[commentsCount];

        //    for (int i = 0; i < commentsCount; i++)
        //    {
        //        comments[i] = new Comment
        //        {
        //            UserId = i + 1,
        //            Content = $"Content{i}"
        //        };
        //    }

        //    return comments;
        //}

        private static CommentLike[] AddCommentLikesToDatabase()
        {
            int commentLikesCount = 10;
            var commentLikes = new CommentLike[commentLikesCount];

            for (int i = 0; i < commentLikesCount; i++)
            {
                commentLikes[i] = new CommentLike
                {
                    UserId = i + 1,
                    CommentId = i + 1
                };
            }

            return commentLikes;
        }

        private static CommentReport[] AddCommentReportsToDatabase()
        {
            int commentReportsCount = 10;
            var commentReports = new CommentReport[commentReportsCount];

            for (int i = 0; i < commentReportsCount; i++)
            {
                commentReports[i] = new CommentReport
                {
                    AccuserId = i + 1,
                    CommentId = i + 1
                };
            }

            return commentReports;
        }

        private static Country[] AddCountriesToDatabase()
        {
            int countiresCount = 10;
            var countires = new Country[countiresCount];

            for (int i = 0; i < countiresCount; i++)
            {
                countires[i] = new Country
                {
                    Name = $"Name{i}"
                };
            }

            return countires;
        }

        private static Following[] AddFollowingsToDatabase()
        {
            int followingsCount = 9;
            var followings = new Following[followingsCount];

            for (int i = 0; i < followingsCount; i++)
            {
                followings[i] = new Following
                {
                    UserId = i + 1,
                    FollowerId = i + 2
                };
            }

            return followings;
        }

        //private static Like[] AddLikesToDatabase()
        //{
        //    int likesCount = 10;
        //    var likes = new Like[likesCount];

        //    for (int i = 0; i < likesCount; i++)
        //    {
        //        likes[i] = new Like
        //        {
        //            UserId = i + 1
        //        };
        //    }

        //    return likes;
        //}

        private static Post[] AddPostsToDatabase()
        {
            int postsCount = 10;
            var posts = new Post[postsCount];

            for (int i = 0; i < postsCount; i++)
            {
                posts[i] = new Post
                {
                    UserId = i + 1,
                    Description = $"Description{i}",
                    PhotoPath = $"PhotoPath{i}"
                };
            }

            return posts;
        }

        private static PostComment[] AddPostCommentsToDatabase()
        {
            int postCommentsCount = 10;
            var postComments = new PostComment[postCommentsCount];

            for (int i = 0; i < postCommentsCount; i++)
            {
                postComments[i] = new PostComment
                {
                    UserId = i + 1,
                    Content = $"Content{i}",
                    PostId = i + 1
                };
            }

            return postComments;
        }

        private static PostLike[] AddPostLikesToDatabase()
        {
            int postLikesCount = 10;
            var postLikes = new PostLike[postLikesCount];

            for (int i = 0; i < postLikesCount; i++)
            {
                postLikes[i] = new PostLike
                {
                    UserId = i + 1,
                    PostId = i + 1
                };
            }

            return postLikes;
        }

        private static PostReport[] AddPostReportsToDatabase()
        {
            int postReportsCount = 10;
            var postReports = new PostReport[postReportsCount];

            for (int i = 0; i < postReportsCount; i++)
            {
                postReports[i] = new PostReport
                {
                    Id = i + 1,
                    PostId = i + 1
                };
            }

            return postReports;
        }

        //private static Report[] AddReportsToDatabase()
        //{
        //    int reportsCount = 10;
        //    var reports = new Report[reportsCount];

        //    for (int i = 0; i < reportsCount; i++)
        //    {
        //        reports[i] = new Report
        //        {
        //            AccuserId = i + 1
        //        };
        //    }

        //    return reports;
        //}

        private static User[] AddUsersToDatabase()
        {
            int usersCount = 10;
            var users = new User[usersCount];

            for (int i = 0; i < usersCount; i++)
            {
                users[i] = new User
                {
                    FirstName = $"FirstName{i}",
                    LastName = $"LastName{i}",
                    BirthDate = DateTime.UtcNow,
                    Gender = Gender.Male,
                    AvatarPath = $"AvatarPath{i}",
                    CountryId = i + 1
                };
            }

            return users;
        }
    }
}
