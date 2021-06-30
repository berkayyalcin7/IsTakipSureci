using IsTakipSureci.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IsTakipSureci.DataAccess.Concrete.EntityFrameworkCore.MappingConfig
{
    public class ReportMap : IEntityTypeConfiguration<Report>
    {
        public void Configure(EntityTypeBuilder<Report> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.ReportTitle).HasMaxLength(70).IsRequired();

            builder.Property(x => x.ReportDescription).HasColumnType("ntext");

            builder.HasOne(x => x.Work).WithMany(x => x.Reports).HasForeignKey(x => x.WorkId);
        }
    }
}
