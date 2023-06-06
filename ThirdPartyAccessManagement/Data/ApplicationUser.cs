using Microsoft.AspNetCore.Identity;

namespace ThirdPartyAccessManagement.Data
{
    public class UserManager : IdentityUser
    {
        public string? Name { get; set; }
    }
}
