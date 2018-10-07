using Vuighe.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Vuighe.Model.EntityConfigurations
{
    public class CategoryTagEntityConfiguration: IEntityTypeConfiguration<CategoryTag>
    {
        public void Configure(EntityTypeBuilder<CategoryTag> builder)
        {
            builder.HasOne(x => x.Category)
                .WithMany(x => x.CategoryTags)
                .HasForeignKey(x => x.CategoryId);

            builder.HasOne(x => x.Tag)
                .WithMany(x => x.CategoryTags)
                .HasForeignKey(x => x.TagId);
        }
    }
}