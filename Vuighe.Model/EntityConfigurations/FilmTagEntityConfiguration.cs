using Vuighe.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Vuighe.Model.EntityConfigurations
{
    public class FilmTagEntityConfiguration : IEntityTypeConfiguration<FilmTag>
    {
        public void Configure(EntityTypeBuilder<FilmTag> builder)
        {
            builder.HasOne(x => x.Film)
                .WithMany(x => x.FilmTags)
                .HasForeignKey(x => x.FilmId);

            builder.HasOne(x => x.Tag)
                .WithMany(x => x.FilmTags)
                .HasForeignKey(x => x.TagId);
        }
    }
}