using Microsoft.AspNetCore.Identity;
using static ThirdPartyAccessManagement.Constants.Constants;

namespace ThirdPartyAccessManagement.Data
{
    public class DbSeeder
    {
        public static async Task SeedDbAsync(IServiceProvider service)
        {
            //Seed Roles
            var userManager = service.GetService<UserManager<UserManager>>();
            var roleManager = service.GetService<RoleManager<IdentityRole>>();
            await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.User.ToString()));
        }
    }
}
