using IsTakipSureci.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace IsTakipSureci.DataAccess.Concrete.EntityFrameworkCore.MappingConfig
{
    public class LevelMap : IEntityTypeConfiguration<Level>
    {
        public void Configure(EntityTypeBuilder<Level> builder)
        {
            builder.Property(x => x.Tanim).HasMaxLength(100);
        }
    }
}
