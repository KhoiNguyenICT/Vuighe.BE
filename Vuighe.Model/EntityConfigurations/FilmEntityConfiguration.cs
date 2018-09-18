using Vuighe.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Vuighe.Model.EntityConfigurations
{
    public class FilmEntityConfiguration: IEntityTypeConfiguration<Film>
    {
        public void Configure(EntityTypeBuilder<Film> builder)
        {
            builder.HasIndex(x => x.Title);

            builder.HasMany(x => x.Episodes)
                .WithOne(x => x.Film)
                .HasForeignKey(x => x.FilmId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}