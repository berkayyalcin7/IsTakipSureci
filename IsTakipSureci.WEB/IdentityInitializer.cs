using IsTakipSureci.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsTakipSureci.WEB
{
    public static class IdentityInitializer
    {
        //public static async Task SeedData(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        //{
        //    var adminRole = await roleManager.FindByNameAsync("Admin");

        //    if (adminRole == null)
        //    {
        //        await roleManager.CreateAsync(new AppRole { Name = "Admin" });
        //    }

        //    var memberRole = await roleManager.FindByNameAsync("Member");

        //    if (memberRole == null)
        //    {
        //        await roleManager.CreateAsync(new AppRole { Name = "Member" });
        //    }

        //    var memberUser = await userManager.FindByNameAsync("ozgurozan");

        //    if (memberUser == null)
        //    {
        //        AppUser appUser = new AppUser
        //        {
        //            Name = "Özgür",
        //            Surname = "Ozan",
        //            UserName = "ozgurozan",
        //            Email = "ozgurozan@hotmail.com"

        //        };

        //        await userManager.CreateAsync(appUser, "1");
        //        // Kullanıcıya Rolü'de atadık.
        //        await userManager.AddToRoleAsync(appUser, "Member");


        //    }
        //}
    }
}
