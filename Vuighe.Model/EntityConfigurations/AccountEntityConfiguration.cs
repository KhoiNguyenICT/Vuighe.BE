using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vuighe.Model.Entities;

namespace Vuighe.Model.EntityConfigurations
{
    public class AccountEntityConfiguration: IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasOne(x => x.ProfileImage).WithOne()
                .HasForeignKey<Account>(x => x.ProfileImageId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}