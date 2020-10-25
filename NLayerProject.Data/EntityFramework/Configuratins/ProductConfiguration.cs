using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayerProject.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLayerProject.Data.EntityFramework.Configuratins
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products"); //tablo adı
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn(); // id bir bir artsın
            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);//name alanı boş geçilemez ve max karakter 200
            builder.Property(x => x.Stock).IsRequired(); //stock alanı boş geçilemez

            builder.Property(x => x.Price).IsRequired().HasColumnType("decimal(18,2)"); //price alanı boş geçilemez ve tipi

            builder.Property(x => x.InnerBarcode).HasMaxLength(50); //InnerBarcode alanı mac karakter 50
        }
    }
}
