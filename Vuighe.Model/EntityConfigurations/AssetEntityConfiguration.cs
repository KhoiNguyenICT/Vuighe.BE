﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NpgsqlTypes;
using Vuighe.Model.Entities;

namespace Vuighe.Model.EntityConfigurations
{
    public class AssetEntityConfiguration : IEntityTypeConfiguration<Asset>
    {
        public void Configure(EntityTypeBuilder<Asset> builder)
        {
            builder.HasIndex(x => x.FileName);

            builder.HasOne(x => x.Collection)
                .WithMany(x => x.Assets)
                .HasForeignKey(x => x.CollectionId);

            builder.Property<NpgsqlTsVector>("SearchVector");
            builder.HasIndex("SearchVector").ForNpgsqlHasMethod("GIN");
        }
    }
}