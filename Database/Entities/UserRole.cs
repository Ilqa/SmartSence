using Microsoft.AspNetCore.Identity;

namespace SmartSence.Database.Entities
{
    public class UserRole : IdentityRole<long>
    {

    }
    public static class UserRoles
    {
        public const string SuperAdmin = "Super Admin";
        public const string Admin = "Admin";
        public const string User = "User";
    }
}
