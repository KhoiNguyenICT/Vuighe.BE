using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NpgsqlTypes;
using Vuighe.Model.Entities;

namespace Vuighe.Model.EntityConfigurations
{
    public class TagEntityConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.HasIndex(x => x.Name);

            builder.Property<NpgsqlTsVector>("SearchVector");
            builder.HasIndex("SearchVector").ForNpgsqlHasMethod("GIN");
        }
    }
}