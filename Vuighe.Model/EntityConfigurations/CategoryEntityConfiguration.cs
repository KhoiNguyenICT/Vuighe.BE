using Vuighe.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NpgsqlTypes;

namespace Vuighe.Model.EntityConfigurations
{
    public class CategoryEntityConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasIndex(x => x.Title);

            builder.HasOne(x => x.Thumbnail).WithOne()
                .HasForeignKey<Category>(x => x.ThumbnailId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.Property<NpgsqlTsVector>("SearchVector");
            builder.HasIndex("SearchVector").ForNpgsqlHasMethod("GIN");
        }
    }
}