﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Data.EF.Extensions;
using OnlineShop.Data.Entities;

namespace OnlineShop.Data.EF.Configurations
{
    public class FooterConfiguration : ModelBuilderExtensions.DbEntityConfiguration<Footer>
    {
        public override void Configure(EntityTypeBuilder<Footer> entity)
        {
            entity.HasKey(n => n.Id);
            entity.Property(n => n.Id).HasMaxLength(255).HasColumnType("varchar(255)").IsRequired();
        }
        
    }
}