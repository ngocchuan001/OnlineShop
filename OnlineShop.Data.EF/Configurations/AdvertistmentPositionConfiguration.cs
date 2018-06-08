using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Data.EF.Extensions;
using OnlineShop.Data.Entities;

namespace OnlineShop.Data.EF.Configurations
{
    public class AdvertistmentPositionConfiguration : DbEntityConfiguration<AdvertistmentPosition>
    {
        public override void Configure(EntityTypeBuilder<AdvertistmentPosition> entity)
        {
            entity.Property(n => n.Id).HasMaxLength(20).IsRequired();
        }
    }
}