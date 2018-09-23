using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vuighe.Model.Entities;

namespace Vuighe.Model.EntityConfigurations
{
    public class AssetEntityConfiguration: IEntityTypeConfiguration<Asset>
    {
        public void Configure(EntityTypeBuilder<Asset> builder)
        {
            builder.HasIndex(x => x.FileName);

            builder.HasOne(x => x.Collection).WithMany(x => x.Assets).HasForeignKey(x => x.CollectionId);
        }
    }
}