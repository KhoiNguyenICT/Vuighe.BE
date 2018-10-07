using Vuighe.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NpgsqlTypes;

namespace Vuighe.Model.EntityConfigurations
{
    public class EpisodeEntityConfiguration: IEntityTypeConfiguration<Episode>
    {
        public void Configure(EntityTypeBuilder<Episode> builder)
        {
            builder.HasIndex(x => x.Title);

            builder.Property<NpgsqlTsVector>("SearchVector");
            builder.HasIndex("SearchVector").ForNpgsqlHasMethod("GIN");
        }
    }
}