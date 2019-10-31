﻿// <auto-generated />
using System;
using DieteticSNS.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DieteticSNS.Persistence.Migrations
{
    [DbContext(typeof(DieteticSNSDbContext))]
    partial class DieteticSNSDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DieteticSNS.Domain.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Comment");
                });

            modelBuilder.Entity("DieteticSNS.Domain.Entities.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("DieteticSNS.Domain.Entities.Following", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("FollowerId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("UserId", "FollowerId");

                    b.HasIndex("FollowerId");

                    b.ToTable("Followings");
                });

            modelBuilder.Entity("DieteticSNS.Domain.Entities.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Carbohydrate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.Property<int?>("Fat")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.Property<string>("Name");

                    b.Property<int?>("Protein")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.HasKey("Id");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("DieteticSNS.Domain.Entities.Like", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Likes");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Like");
                });

            modelBuilder.Entity("DieteticSNS.Domain.Entities.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Description");

                    b.Property<string>("ImageURL");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("DieteticSNS.Domain.Entities.Recipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Description");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("DieteticSNS.Domain.Entities.RecipeIngredient", b =>
                {
                    b.Property<int>("RecipeId");

                    b.Property<int>("IngredientId");

                    b.Property<int>("Quantity");

                    b.Property<int>("Unit");

                    b.HasKey("RecipeId", "IngredientId");

                    b.HasIndex("IngredientId");

                    b.ToTable("RecipeIngredients");
                });

            modelBuilder.Entity("DieteticSNS.Domain.Entities.Report", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccuserId");

                    b.Property<string>("Content");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.HasIndex("AccuserId");

                    b.ToTable("Reports");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Report");
                });

            modelBuilder.Entity("DieteticSNS.Domain.Entities.Stars", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Stars");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Stars");
                });

            modelBuilder.Entity("DieteticSNS.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("AvatarPath");

                    b.Property<DateTime?>("BirthDate");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<int?>("CountryId");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<int?>("Gender");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<int>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("DieteticSNS.Domain.Entities.PostComment", b =>
                {
                    b.HasBaseType("DieteticSNS.Domain.Entities.Comment");

                    b.Property<int>("PostId");

                    b.HasIndex("PostId");

                    b.HasDiscriminator().HasValue("PostComment");
                });

            modelBuilder.Entity("DieteticSNS.Domain.Entities.RecipeComment", b =>
                {
                    b.HasBaseType("DieteticSNS.Domain.Entities.Comment");

                    b.Property<int>("RecipeId");

                    b.HasIndex("RecipeId");

                    b.HasDiscriminator().HasValue("RecipeComment");
                });

            modelBuilder.Entity("DieteticSNS.Domain.Entities.CommentLike", b =>
                {
                    b.HasBaseType("DieteticSNS.Domain.Entities.Like");

                    b.Property<int>("CommentId");

                    b.HasIndex("CommentId");

                    b.HasDiscriminator().HasValue("CommentLike");
                });

            modelBuilder.Entity("DieteticSNS.Domain.Entities.PostLike", b =>
                {
                    b.HasBaseType("DieteticSNS.Domain.Entities.Like");

                    b.Property<int>("PostId");

                    b.HasIndex("PostId");

                    b.HasDiscriminator().HasValue("PostLike");
                });

            modelBuilder.Entity("DieteticSNS.Domain.Entities.CommentReport", b =>
                {
                    b.HasBaseType("DieteticSNS.Domain.Entities.Report");

                    b.Property<int>("CommentId");

                    b.HasIndex("CommentId");

                    b.HasDiscriminator().HasValue("CommentReport");
                });

            modelBuilder.Entity("DieteticSNS.Domain.Entities.PostReport", b =>
                {
                    b.HasBaseType("DieteticSNS.Domain.Entities.Report");

                    b.Property<int>("PostId");

                    b.HasIndex("PostId");

                    b.HasDiscriminator().HasValue("PostReport");
                });

            modelBuilder.Entity("DieteticSNS.Domain.Entities.RecipeReport", b =>
                {
                    b.HasBaseType("DieteticSNS.Domain.Entities.Report");

                    b.Property<int>("RecipeId");

                    b.HasIndex("RecipeId");

                    b.HasDiscriminator().HasValue("RecipeReport");
                });

            modelBuilder.Entity("DieteticSNS.Domain.Entities.RecipeStars", b =>
                {
                    b.HasBaseType("DieteticSNS.Domain.Entities.Stars");

                    b.Property<int>("RecipeId");

                    b.HasIndex("RecipeId");

                    b.HasDiscriminator().HasValue("RecipeStars");
                });

            modelBuilder.Entity("DieteticSNS.Domain.Entities.Comment", b =>
                {
                    b.HasOne("DieteticSNS.Domain.Entities.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DieteticSNS.Domain.Entities.Following", b =>
                {
                    b.HasOne("DieteticSNS.Domain.Entities.User", "Follower")
                        .WithMany("Followings")
                        .HasForeignKey("FollowerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DieteticSNS.Domain.Entities.User", "User")
                        .WithMany("Followers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("DieteticSNS.Domain.Entities.Like", b =>
                {
                    b.HasOne("DieteticSNS.Domain.Entities.User", "User")
                        .WithMany("Likes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DieteticSNS.Domain.Entities.Post", b =>
                {
                    b.HasOne("DieteticSNS.Domain.Entities.User", "User")
                        .WithMany("Posts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DieteticSNS.Domain.Entities.Recipe", b =>
                {
                    b.HasOne("DieteticSNS.Domain.Entities.User", "User")
                        .WithMany("Recipes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DieteticSNS.Domain.Entities.RecipeIngredient", b =>
                {
                    b.HasOne("DieteticSNS.Domain.Entities.Ingredient", "Ingredient")
                        .WithMany("RecipeIngredients")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DieteticSNS.Domain.Entities.Recipe", "Recipe")
                        .WithMany("RecipeIngredients")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DieteticSNS.Domain.Entities.Report", b =>
                {
                    b.HasOne("DieteticSNS.Domain.Entities.User", "Accuser")
                        .WithMany("Reports")
                        .HasForeignKey("AccuserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DieteticSNS.Domain.Entities.Stars", b =>
                {
                    b.HasOne("DieteticSNS.Domain.Entities.User", "User")
                        .WithMany("Stars")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DieteticSNS.Domain.Entities.User", b =>
                {
                    b.HasOne("DieteticSNS.Domain.Entities.Country", "Country")
                        .WithMany("Users")
                        .HasForeignKey("CountryId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("DieteticSNS.Domain.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("DieteticSNS.Domain.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DieteticSNS.Domain.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("DieteticSNS.Domain.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DieteticSNS.Domain.Entities.PostComment", b =>
                {
                    b.HasOne("DieteticSNS.Domain.Entities.Post", "Post")
                        .WithMany("PostComments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("DieteticSNS.Domain.Entities.RecipeComment", b =>
                {
                    b.HasOne("DieteticSNS.Domain.Entities.Recipe", "Recipe")
                        .WithMany("RecipeComments")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("DieteticSNS.Domain.Entities.CommentLike", b =>
                {
                    b.HasOne("DieteticSNS.Domain.Entities.Comment", "Comment")
                        .WithMany("CommentLikes")
                        .HasForeignKey("CommentId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("DieteticSNS.Domain.Entities.PostLike", b =>
                {
                    b.HasOne("DieteticSNS.Domain.Entities.Post", "Post")
                        .WithMany("PostLikes")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("DieteticSNS.Domain.Entities.CommentReport", b =>
                {
                    b.HasOne("DieteticSNS.Domain.Entities.Comment", "Comment")
                        .WithMany("CommentReports")
                        .HasForeignKey("CommentId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("DieteticSNS.Domain.Entities.PostReport", b =>
                {
                    b.HasOne("DieteticSNS.Domain.Entities.Post", "Post")
                        .WithMany("PostReports")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("DieteticSNS.Domain.Entities.RecipeReport", b =>
                {
                    b.HasOne("DieteticSNS.Domain.Entities.Recipe", "Recipe")
                        .WithMany("RecipeReports")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("DieteticSNS.Domain.Entities.RecipeStars", b =>
                {
                    b.HasOne("DieteticSNS.Domain.Entities.Recipe", "Recipe")
                        .WithMany("RecipeStars")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
