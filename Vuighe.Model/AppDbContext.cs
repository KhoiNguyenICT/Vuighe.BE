﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Vuighe.Common.Interfaces;
using Vuighe.Model.Entities;
using Vuighe.Model.EntityConfigurations;

namespace Vuighe.Model
{
    public class AppDbContext : IdentityDbContext<Account, IdentityRole<Guid>, Guid>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Asset> Assets { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<CategoryFilm> CategoryFilms { get; set; }

        public virtual DbSet<Collection> Collections { get; set; }

        public virtual DbSet<CategoryTag> CategoryTags { get; set; }

        public virtual DbSet<ConfigurationValue> ConfigurationValues { get; set; }

        public virtual DbSet<Episode> Episodes { get; set; }

        public virtual DbSet<EpisodeTag> EpisodeTags { get; set; }

        public virtual DbSet<Film> Films { get; set; }

        public virtual DbSet<FilmTag> FilmTags { get; set; }

        public virtual DbSet<Log> Logs { get; set; }

        public virtual DbSet<LoginHistory> LoginHistories { get; set; }

        public virtual DbSet<Comment> Comments { get; set; }

        public virtual DbSet<Tag> Tags { get; set; }

        public virtual DbSet<Post> Posts { get; set; }

        public virtual DbSet<PostTag> PostTags { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AccountEntityConfiguration());
            builder.ApplyConfiguration(new AssetEntityConfiguration());
            builder.ApplyConfiguration(new CategoryEntityConfiguration());
            builder.ApplyConfiguration(new CategoryFilmEntityConfiguration());
            builder.ApplyConfiguration(new CategoryFilmEntityConfiguration());
            builder.ApplyConfiguration(new CategoryTagEntityConfiguration());
            builder.ApplyConfiguration(new CommentEntityConfiguration());
            builder.ApplyConfiguration(new EpisodeEntityConfiguration());
            builder.ApplyConfiguration(new EpisodeTagEntityConfiguration());
            builder.ApplyConfiguration(new FilmEntityConfiguration());
            builder.ApplyConfiguration(new FilmTagEntityConfiguration());
            builder.ApplyConfiguration(new PostEntityConfiguration());
            builder.ApplyConfiguration(new PostTagEntityConfiguration());
            builder.ApplyConfiguration(new TagEntityConfiguration());
            base.OnModelCreating(builder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var modified = ChangeTracker.Entries().Where(e => e.State == EntityState.Modified || e.State == EntityState.Added);
            foreach (EntityEntry item in modified)
            {
                if (item.Entity is IEntity changedOrAddedItem)
                {
                    if (item.State == EntityState.Added)
                    {
                        changedOrAddedItem.CreatedDate = DateTime.Now;
                    }

                    changedOrAddedItem.UpdatedDate = DateTime.Now;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}