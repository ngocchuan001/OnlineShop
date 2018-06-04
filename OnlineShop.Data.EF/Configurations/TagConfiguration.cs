using OnlineShop.Data.EF.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Data.Entities;

namespace OnlineShop.Data.EF.Configurations
{
    public class TagConfiguration : ModelBuilderExtensions.DbEntityConfiguration<Tag>
    {
        public override void Configure(EntityTypeBuilder<Tag> entity)
        {
            entity.Property(n => n.Id).HasMaxLength(50)
                .IsRequired().HasColumnType("varchar(50)");
        }
    }
}