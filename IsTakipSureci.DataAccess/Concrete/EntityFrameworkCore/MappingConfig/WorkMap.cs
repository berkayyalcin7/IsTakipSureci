using IsTakipSureci.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace IsTakipSureci.DataAccess.Concrete.EntityFrameworkCore.MappingConfig
{
    public class WorkMap : IEntityTypeConfiguration<Work>
    {
        
        public void Configure(EntityTypeBuilder<Work> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.WorkName).HasMaxLength(100).IsRequired();
            // Kolon tipini nvarchar değil ntext olarak ayarlıyoruz.
            builder.Property(x => x.Description).HasColumnType("ntext");
            // Aciliyeti sildirmeyeceğiz : Eğer silersek Görevde silinecek . 
            builder.HasOne(x => x.Level).WithMany(x => x.Works).HasForeignKey(x => x.LevelId);

           


        }
    }
}
