using Microsoft.AspNetCore.Identity;
using ThirdPartyAccessManagement.Constants;

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

			//Database Context
			var context = service.GetService<ApplicationDbContext>();

			// For Third Party User Status
			if (!context.ThirdPartyUserStatuses.Any())
			{
				var userStatuses = Enum.GetValues(typeof(ThirdPartyUserStatusTypes)).Cast<ThirdPartyUserStatusTypes>();
				foreach (var userStatus in userStatuses)
				{
					context.ThirdPartyUserStatuses.Add(new ThirdPartyUserStatus
					{
						Status = userStatus.ToString()
					});
					await context.SaveChangesAsync();
				}
			}
		}
    }
}
