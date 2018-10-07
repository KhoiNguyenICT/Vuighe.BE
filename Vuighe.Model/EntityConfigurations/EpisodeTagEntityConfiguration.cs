using Vuighe.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Vuighe.Model.EntityConfigurations
{
    public class EpisodeTagEntityConfiguration : IEntityTypeConfiguration<EpisodeTag>
    {
        public void Configure(EntityTypeBuilder<EpisodeTag> builder)
        {
            builder.HasOne(x => x.Episode)
                .WithMany(x => x.EpisodeTags)
                .HasForeignKey(x => x.EpisodeId);

            builder.HasOne(x => x.Tag)
                .WithMany(x => x.EpisodeTags)
                .HasForeignKey(x => x.TagId);
        }
    }
}