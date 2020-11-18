using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLayerProject.Data.EntityFramework.Configuratins
{
    public abstract class EntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : class,new()
    {
       /// <summary>
       /// Base ayarlar için kullanılıyor reflection ile
       /// </summary>
       /// <param name="builder"></param>
         public void Configure(EntityTypeBuilder<TEntity> builder)
        {

            Type entityType = typeof(TEntity);
            var entity = Activator.CreateInstance(entityType);
            var entityFields = entity.GetType().GetFields();

            builder.ToTable(entity.GetType().Name+"s");
            foreach (var item in entityFields)
            {
                if (item.Name == "Id")
                {
                    builder.HasKey(item.GetType().Name);
                    builder.Property(item.GetType().Name).UseIdentityColumn();
                }
                if(item.Name=="Name")
                {
                    builder.Property(item.GetType().Name).IsRequired().HasMaxLength(200);
                }
            }
        }
    }
}
