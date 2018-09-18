using Vuighe.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Vuighe.Model.EntityConfigurations
{
    public class CategoryFilmEntityConfiguration: IEntityTypeConfiguration<CategoryFilm>
    {
        public void Configure(EntityTypeBuilder<CategoryFilm> builder)
        {

            builder.HasOne(x => x.Category)
                .WithMany(x => x.CategoryFilms)
                .HasForeignKey(x => x.CategoryId);

            builder.HasOne(x => x.Film)
                .WithMany(x => x.CategoryFilms)
                .HasForeignKey(x => x.FilmId);
        }
    }
}