using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayerProject.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLayerProject.Data.EntityFramework.Seed
{
   public class ProductSeed:IEntityTypeConfiguration<Product>
    {
        private readonly int[] _ids;
        public ProductSeed(int[] ids)
        {
            _ids = ids;
        }

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            //Ef de default data basılıyorsa mutlaka id belirtmek gerekli
            builder.HasData(
                new Product
                {
                    Id = 1,
                    Name = "Pilot Kalem",
                    Price = 12.50m,
                    Stock = 100,
                    CategoryId = _ids[0]
                }, new Product
                {
                    Id = 2,
                    Name = "Kurşun Kalem",
                    Price = 40.50m,
                    Stock = 300,
                    CategoryId = _ids[0]
                },
                new Product
                {
                    Id = 3,
                    Name = "Tükenmez Kalem",
                    Price = 50.50m,
                    Stock = 100,
                    CategoryId = _ids[0]
                },
                new Product
                {
                    Id = 4,
                    Name = "Küçük Boy Defter",
                    Price = 12.50m,
                    Stock = 100,
                    CategoryId = _ids[1]
                }, new Product
                {
                    Id = 5,
                    Name = "Kareli Defter",
                    Price = 12.50m,
                    Stock = 100,
                    CategoryId = _ids[1]
                }


                );
        }
    }
}
