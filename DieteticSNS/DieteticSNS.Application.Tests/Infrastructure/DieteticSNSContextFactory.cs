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

            context.Comments.AddRange(AddCommentsToDatabase());
            context.CommentLikes.AddRange(AddCommentLikesToDatabase());
            context.CommentReports.AddRange(AddCommentReportsToDatabase());
            context.Countries.AddRange(AddCountriesToDatabase());
            context.Followings.AddRange(AddFollowingsToDatabase());
            context.Ingredients.AddRange(AddIngredientsToDatabase());
            context.Likes.AddRange(AddLikesToDatabase());
            context.Posts.AddRange(AddPostsToDatabase());
            context.PostComments.AddRange(AddPostCommentsToDatabase());
            context.PostLikes.AddRange(AddPostLikesToDatabase());
            context.PostReports.AddRange(AddPostReportsToDatabase());
            context.Recipes.AddRange(AddRecipesToDatabase());
            context.RecipeComments.AddRange(AddRecipeCommentsToDatabase());
            context.RecipeIngredients.AddRange(AddRecipeIngredientsToDatabase());
            context.RecipeReports.AddRange(AddRecipeReportsToDatabase());
            context.RecipeStars.AddRange(AddRecipeStarsToDatabase());
            context.Reports.AddRange(AddReportsToDatabase());
            context.Stars.AddRange(AddStarsToDatabase());
            context.Users.AddRange(AddUsersToDatabase());

            context.SaveChanges();

            return context;
        }

        public static void Destroy(DieteticSNSDbContext context)
        {
            context.Database.EnsureDeleted();

            context.Dispose();
        }

        private static Comment[] AddCommentsToDatabase()
        {
            int commentsCount = 10;
            var comments = new Comment[commentsCount];

            for (int i = 0; i < commentsCount; i++)
            {
                comments[i] = new Comment
                {
                    UserId = i + 1,
                    Content = $"Content{i}"
                };
            }

            return comments;
        }

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
                    Content = $"Content{i}",
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

        private static Ingredient[] AddIngredientsToDatabase()
        {
            int ingredientsCount = 10;
            var ingredients = new Ingredient[ingredientsCount];

            for (int i = 0; i < ingredientsCount; i++)
            {
                ingredients[i] = new Ingredient
                {
                    Name = $"Name{i}",
                    Protein = i + 1,
                    Carbohydrate = i + 1,
                    Fat = i + 1
                };
            }

            return ingredients;
        }

        private static Like[] AddLikesToDatabase()
        {
            int likesCount = 10;
            var likes = new Like[likesCount];

            for (int i = 0; i < likesCount; i++)
            {
                likes[i] = new Like
                {
                    UserId = i + 1
                };
            }

            return likes;
        }

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
                    ImageURL = $"ImageURL{i}"
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
                    Content = $"Content{i}",
                    PostId = i + 1
                };
            }

            return postReports;
        }

        private static Recipe[] AddRecipesToDatabase()
        {
            int recipesCount = 10;
            var recipes = new Recipe[recipesCount];

            for (int i = 0; i < recipesCount; i++)
            {
                recipes[i] = new Recipe
                {
                    UserId = i + 1,
                    Description = $"Description{i}"
                };
            }

            return recipes;
        }

        private static RecipeComment[] AddRecipeCommentsToDatabase()
        {
            int recipeCommentsCount = 10;
            var recipeComments = new RecipeComment[recipeCommentsCount];

            for (int i = 0; i < recipeCommentsCount; i++)
            {
                recipeComments[i] = new RecipeComment
                {
                    UserId = i + 1,
                    Content = $"Content{i}",
                    RecipeId = i + 1
                };
            }

            return recipeComments;
        }

        private static RecipeIngredient[] AddRecipeIngredientsToDatabase()
        {
            int recipeIngredientsCount = 10;
            var recipeIngredients = new RecipeIngredient[recipeIngredientsCount];

            for (int i = 0; i < recipeIngredientsCount; i++)
            {
                recipeIngredients[i] = new RecipeIngredient
                {
                    RecipeId = i + 1,
                    IngredientId = i + 1,
                    Quantity = i + 1,
                    Unit = Unit.Gram
                };
            }

            return recipeIngredients;
        }

        private static RecipeReport[] AddRecipeReportsToDatabase()
        {
            int recipeReportsCount = 10;
            var recipeReports = new RecipeReport[recipeReportsCount];

            for (int i = 0; i < recipeReportsCount; i++)
            {
                recipeReports[i] = new RecipeReport
                {
                    AccuserId = i + 1,
                    Content = $"Content{i}",
                    RecipeId = i + 1
                };
            }

            return recipeReports;
        }

        private static RecipeStars[] AddRecipeStarsToDatabase()
        {
            int recipeStarsCount = 10;
            var recipeStars = new RecipeStars[recipeStarsCount];

            for (int i = 0; i < recipeStarsCount; i++)
            {
                recipeStars[i] = new RecipeStars
                {
                    UserId = i + 1,
                    Amount = i + 1,
                    RecipeId = i + 1
                };
            }

            return recipeStars;
        }

        private static Report[] AddReportsToDatabase()
        {
            int reportsCount = 10;
            var reports = new Report[reportsCount];

            for (int i = 0; i < reportsCount; i++)
            {
                reports[i] = new Report
                {
                    AccuserId = i + 1,
                    Content = $"Content{i}"
                };
            }

            return reports;
        }

        private static Stars[] AddStarsToDatabase()
        {
            int starsCount = 10;
            var stars = new Stars[starsCount];

            for (int i = 0; i < starsCount; i++)
            {
                stars[i] = new Stars
                {
                    UserId = i + 1,
                    Amount = i + 1
                };
            }

            return stars;
        }

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
