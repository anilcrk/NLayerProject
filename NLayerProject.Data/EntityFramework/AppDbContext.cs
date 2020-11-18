using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using NLayerProject.Core.Model;
using NLayerProject.Data.EntityFramework.Configuratins;
using NLayerProject.Data.EntityFramework.Seed;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLayerProject.Data.EntityFramework
{
  public  class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Country> Countries { get; set; }

       public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)///veri tabanında tablolar oluşmadan önce çalışcak metod
        {
            //configuration cs ler modelBuildera eklendi
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new PersonConfiguration());
            modelBuilder.ApplyConfiguration(new CountryConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
           modelBuilder.ApplyConfiguration(new UserRoleConfiguration());

            modelBuilder.ApplyConfiguration(new ProductSeed(new int[] { 1,2})); //default datalar product için
            modelBuilder.ApplyConfiguration(new CategorySeed(new int[] { 1,2}));//default datalar category için
            modelBuilder.ApplyConfiguration(new CountrySeed());
        }
    }

}
