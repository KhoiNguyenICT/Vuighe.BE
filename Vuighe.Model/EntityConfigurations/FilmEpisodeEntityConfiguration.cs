using Vuighe.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Vuighe.Model.EntityConfigurations
{
    public class FilmEpisodeEntityConfiguration : IEntityTypeConfiguration<FilmEpisode>
    {
        public void Configure(EntityTypeBuilder<FilmEpisode> builder)
        {
            builder.HasKey(x => new {x.EpisodeId, x.FilmId});

            builder.HasOne(x => x.Film)
                .WithMany(x => x.FilmEpisodes)
                .HasForeignKey(x => x.FilmId);

            builder.HasOne(x => x.Episode)
                .WithMany(x => x.FilmEpisodes)
                .HasForeignKey(x => x.EpisodeId);
        }
    }
}