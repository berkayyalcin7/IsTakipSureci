using IsTakipSureci.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace IsTakipSureci.DataAccess.Concrete.EntityFrameworkCore.MappingConfig
{
    public class NotifyMap : IEntityTypeConfiguration<Notify>
    {
        public void Configure(EntityTypeBuilder<Notify> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Description).HasColumnType("ntext").IsRequired();

            builder.HasOne(x => x.AppUser).WithMany(x => x.Notifys).HasForeignKey(x => x.AppUserId);
          
        }
    }
}
