using IsTakipSureci.DataAccess.Concrete.EntityFrameworkCore.MappingConfig;
using IsTakipSureci.Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace IsTakipSureci.DataAccess.Concrete.EntityFrameworkCore.Contexts
{
    //Burada IdentityDbContext'e user ve rol sınıflarımızı belirttik ve PK 'yı int olarak belirttik
    public class IsSureciContext: IdentityDbContext<AppUser,AppRole,int>
    {
        public IsSureciContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-SM0VBLO;Initial Catalog =IsSureciDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new WorkMap());
            modelBuilder.ApplyConfiguration(new LevelMap());
            modelBuilder.ApplyConfiguration(new ReportMap());
            modelBuilder.ApplyConfiguration(new AppUserMap());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Work> Works { get; set; }
        public DbSet<Level> Levels { get; set; }

        public DbSet<Report> Reports { get; set; }
    }
}
