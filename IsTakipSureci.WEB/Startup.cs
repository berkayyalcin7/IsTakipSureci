using IsTakipSureci.Business.Concrete;
using IsTakipSureci.Business.Interfaces;
using IsTakipSureci.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using IsTakipSureci.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using IsTakipSureci.DataAccess.Interfaces;
using IsTakipSureci.Entities.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace IsTakipSureci.WEB
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            // AddScoped : 1 kullan�c�n�n �ste�i tek instance �zerinden ger�ekle�ir.
            services.AddScoped<IWorkService, WorkManager>();
            services.AddScoped<IReportService, ReportManager>();
            services.AddScoped<ILevelService, LevelManager>();
            services.AddScoped<IAppUserService, AppUserManager>();
            services.AddScoped<IFileService, FileManager>();

            services.AddScoped<IWorkDal, EfWorkRepository>();
            services.AddScoped<IReportDal, EfReportRepository>();
            services.AddScoped<ILevelDal, EfLevelRepository>();
            services.AddScoped<IAppUserDal, EfAppUserRepository>();


            services.AddDbContext<IsSureciContext>();
         

            //Identity' belirtiyoruz ve EntityFramework ile �al��aca��n� belirtiyoruz.
            services.AddIdentity<AppUser, AppRole>(x =>
            {
                x.Password.RequireDigit = false;
                x.Password.RequireUppercase = false;
                x.Password.RequiredLength = 1;
                x.Password.RequireLowercase = false;
                x.Password.RequireNonAlphanumeric = false;
            }).AddEntityFrameworkStores<IsSureciContext>();

            services.ConfigureApplicationCookie(opt =>
            {
                opt.Cookie.Name = "IsTakipCookie";
                opt.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict;
                opt.Cookie.HttpOnly = true;
                opt.ExpireTimeSpan = TimeSpan.FromDays(10);
                // �stek neyse �yle davran HTTP ise HTTP
                opt.Cookie.SecurePolicy = Microsoft.AspNetCore.Http.CookieSecurePolicy.Always;
                opt.LoginPath = "/Home/Index";

            });


            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            //Giri� i�lemleri ve Rol bazl� yetkilendirme i�in

            app.UseAuthentication();

            app.UseAuthorization();

            //Asenkron oldu�u i�in Wait metodunu kulland�k
            //IdentityInitializer.SeedData(userManager, roleManager).Wait();

            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area}/{controller=Home}/{action=Index}/{id?}"
                  );


                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
