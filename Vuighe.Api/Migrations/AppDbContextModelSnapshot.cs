﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using NpgsqlTypes;
using Vuighe.Model;

namespace Vuighe.Api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<Guid>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<Guid>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<Guid>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Vuighe.Model.Entities.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<bool>("IsActive");

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

                    b.Property<Guid?>("ProfileImageId");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<DateTime>("UpdatedDate");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.HasIndex("ProfileImageId");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Vuighe.Model.Entities.Asset", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CollectionId");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("FileExtension")
                        .HasMaxLength(50);

                    b.Property<string>("FileName")
                        .IsRequired();

                    b.Property<string>("FilePath")
                        .IsRequired();

                    b.Property<long>("FileSize");

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("CollectionId");

                    b.HasIndex("FileName");

                    b.ToTable("Assets");
                });

            modelBuilder.Entity("Vuighe.Model.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<NpgsqlTsVector>("SearchVector");

                    b.Property<Guid?>("ThumbnailId");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("SearchVector")
                        .HasAnnotation("Npgsql:IndexMethod", "GIN");

                    b.HasIndex("ThumbnailId");

                    b.HasIndex("Title");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Vuighe.Model.Entities.CategoryFilm", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CategoryId");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<Guid>("FilmId");

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("FilmId");

                    b.ToTable("CategoryFilms");
                });

            modelBuilder.Entity("Vuighe.Model.Entities.CategoryTag", b =>
                {
                    b.Property<Guid>("CategoryId");

                    b.Property<Guid>("TagId");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<Guid>("Id");

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("CategoryId", "TagId");

                    b.HasAlternateKey("Id");

                    b.HasIndex("TagId");

                    b.ToTable("CategoryTags");
                });

            modelBuilder.Entity("Vuighe.Model.Entities.Collection", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Title")
                        .HasMaxLength(500);

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("Id");

                    b.ToTable("Collections");
                });

            modelBuilder.Entity("Vuighe.Model.Entities.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CommentedById");

                    b.Property<string>("Content");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<Guid>("ParentId");

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("CommentedById");

                    b.HasIndex("ParentId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Vuighe.Model.Entities.ConfigurationValue", b =>
                {
                    b.Property<string>("Key")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("UpdatedDate");

                    b.Property<string>("Value");

                    b.HasKey("Key");

                    b.ToTable("ConfigurationValues");
                });

            modelBuilder.Entity("Vuighe.Model.Entities.Episode", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<Guid>("FilmId");

                    b.Property<int>("FollowCount");

                    b.Property<int>("LikeCount");

                    b.Property<Guid?>("ThumbnailId");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<DateTime>("UpdatedDate");

                    b.Property<string>("VideoSource");

                    b.Property<int>("ViewCount");

                    b.HasKey("Id");

                    b.HasIndex("FilmId");

                    b.HasIndex("ThumbnailId");

                    b.HasIndex("Title");

                    b.ToTable("Episodes");
                });

            modelBuilder.Entity("Vuighe.Model.Entities.EpisodeTag", b =>
                {
                    b.Property<Guid>("EpisodeId");

                    b.Property<Guid>("TagId");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<Guid>("Id");

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("EpisodeId", "TagId");

                    b.HasAlternateKey("Id");

                    b.HasIndex("TagId");

                    b.ToTable("EpisodeTags");
                });

            modelBuilder.Entity("Vuighe.Model.Entities.Film", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<int>("FollowCount");

                    b.Property<int>("LikeCount");

                    b.Property<Guid?>("ThumbnailId");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<DateTime>("UpdatedDate");

                    b.Property<int>("ViewCount");

                    b.HasKey("Id");

                    b.HasIndex("ThumbnailId");

                    b.HasIndex("Title");

                    b.ToTable("Films");
                });

            modelBuilder.Entity("Vuighe.Model.Entities.FilmTag", b =>
                {
                    b.Property<Guid>("FilmId");

                    b.Property<Guid>("TagId");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<Guid>("Id");

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("FilmId", "TagId");

                    b.HasAlternateKey("Id");

                    b.HasIndex("TagId");

                    b.ToTable("FilmTags");
                });

            modelBuilder.Entity("Vuighe.Model.Entities.Log", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("Id");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("Vuighe.Model.Entities.LoginHistory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Token");

                    b.Property<DateTime>("UpdatedDate");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("LoginHistories");
                });

            modelBuilder.Entity("Vuighe.Model.Entities.Tag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("Id");

                    b.ToTable("Tag");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("Vuighe.Model.Entities.Account")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("Vuighe.Model.Entities.Account")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Vuighe.Model.Entities.Account")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("Vuighe.Model.Entities.Account")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Vuighe.Model.Entities.Account", b =>
                {
                    b.HasOne("Vuighe.Model.Entities.Asset", "ProfileImage")
                        .WithMany()
                        .HasForeignKey("ProfileImageId");
                });

            modelBuilder.Entity("Vuighe.Model.Entities.Asset", b =>
                {
                    b.HasOne("Vuighe.Model.Entities.Collection", "Collection")
                        .WithMany("Assets")
                        .HasForeignKey("CollectionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Vuighe.Model.Entities.Category", b =>
                {
                    b.HasOne("Vuighe.Model.Entities.Asset", "Thumbnail")
                        .WithMany()
                        .HasForeignKey("ThumbnailId");
                });

            modelBuilder.Entity("Vuighe.Model.Entities.CategoryFilm", b =>
                {
                    b.HasOne("Vuighe.Model.Entities.Category", "Category")
                        .WithMany("CategoryFilms")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Vuighe.Model.Entities.Film", "Film")
                        .WithMany("CategoryFilms")
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Vuighe.Model.Entities.CategoryTag", b =>
                {
                    b.HasOne("Vuighe.Model.Entities.Category", "Category")
                        .WithMany("CategoryTags")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Vuighe.Model.Entities.Tag", "Tag")
                        .WithMany("CategoryTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Vuighe.Model.Entities.Comment", b =>
                {
                    b.HasOne("Vuighe.Model.Entities.Account", "CommentedBy")
                        .WithMany()
                        .HasForeignKey("CommentedById")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Vuighe.Model.Entities.Comment", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Vuighe.Model.Entities.Episode", b =>
                {
                    b.HasOne("Vuighe.Model.Entities.Film", "Film")
                        .WithMany("Episodes")
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Vuighe.Model.Entities.Asset", "Thumbnail")
                        .WithMany()
                        .HasForeignKey("ThumbnailId");
                });

            modelBuilder.Entity("Vuighe.Model.Entities.EpisodeTag", b =>
                {
                    b.HasOne("Vuighe.Model.Entities.Episode", "Episode")
                        .WithMany("EpisodeTags")
                        .HasForeignKey("EpisodeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Vuighe.Model.Entities.Tag", "Tag")
                        .WithMany("EpisodeTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Vuighe.Model.Entities.Film", b =>
                {
                    b.HasOne("Vuighe.Model.Entities.Asset", "Thumbnail")
                        .WithMany()
                        .HasForeignKey("ThumbnailId");
                });

            modelBuilder.Entity("Vuighe.Model.Entities.FilmTag", b =>
                {
                    b.HasOne("Vuighe.Model.Entities.Film", "Film")
                        .WithMany("FilmTags")
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Vuighe.Model.Entities.Tag", "Tag")
                        .WithMany("FilmTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
