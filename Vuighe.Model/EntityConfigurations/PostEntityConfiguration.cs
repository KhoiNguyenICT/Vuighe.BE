using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NpgsqlTypes;
using Vuighe.Model.Entities;

namespace Vuighe.Model.EntityConfigurations
{
    public class PostEntityConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasIndex(x => x.Title);

            builder.Property<NpgsqlTsVector>("SearchVector");
            builder.HasIndex("SearchVector").ForNpgsqlHasMethod("GIN");
        }
    }
}