using IsTakipSureci.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace IsTakipSureci.DataAccess.Concrete.EntityFrameworkCore.MappingConfig
{
    public class AppUserMap : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(50);
            builder.Property(x=>x.Surname).HasMaxLength(50);
            //Çok olan görevler tek olan User FK'mız UserID  : Silindiğinde Null olarak ata
            builder.HasMany(x => x.Works).WithOne(x => x.AppUser).HasForeignKey(x=>x.AppUserId).OnDelete(DeleteBehavior.SetNull);

        }
    }
}
