using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayerProject.Core.Model;
using NLayerProject.Data.EntityFramework.Seed.SeedHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLayerProject.Data.EntityFramework.Seed
{
    public class CountrySeed : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasData(CountrySeedHelper.GetListCountrySeed());
        }
    }
}
