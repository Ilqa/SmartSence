using Microsoft.AspNetCore.Identity;
using SmartSence.Database.Entities;
using SmartSence.Databse.Entities;

namespace SmartSence.Database
{
    public class DatabaseSeeder : IDatabaseSeeder
    {
        private readonly ILogger<DatabaseSeeder> _logger;
        private readonly SmartSenceContext _db;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<UserRole> _roleManager;


        public DatabaseSeeder(
            UserManager<User> userManager,
            RoleManager<UserRole> roleManager,
            SmartSenceContext db,
            ILogger<DatabaseSeeder> logger)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _db = db;
            _logger = logger;
        }

        public void Initialize()
        {
            CreateRoles();
            AddSuperAdmin("ilqa.nawaz@arpatech.com", "ilqa");
            AddSuperAdmin("muhammad.adil@arpatech.com", "adil");

            //_db.SaveChanges();
        }


        private void CreateRoles()
        {
            Task.Run(async () =>
            {
                var superAdminRoleInDb = await _roleManager.FindByNameAsync("Super Admin");
                if (superAdminRoleInDb == null)
                {
                    await _roleManager.CreateAsync(new UserRole() { Name = "Super Admin" });
                    _logger.LogInformation("Seeded Super Admin Role.");
                }
                var adminRoleInDb = await _roleManager.FindByNameAsync("Admin");
                if (adminRoleInDb == null)
                {
                    await _roleManager.CreateAsync(new UserRole() { Name = "Admin" });
                    _logger.LogInformation("Seeded Admin Role.");
                }
                var basicRoleInDb = await _roleManager.FindByNameAsync("Basic");
                if (basicRoleInDb == null)
                {
                    await _roleManager.CreateAsync(new UserRole() { Name = "Basic" });
                    _logger.LogInformation("Seeded Client Role.");
                }
                

            }).GetAwaiter().GetResult();
        }

        private void AddSuperAdmin(string email, string userName)
        {
            Task.Run(async () =>
            {
                var adminRoleInDb = await _roleManager.FindByNameAsync("Super Admin");

                //Check if User Exists
                var superUser = new User()
                {
                    Email = email,
                    UserName = userName,
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    IsActive = true,
                    OrganizationId = null,

                };
                var superUserInDb = await _userManager.FindByEmailAsync(superUser.Email);
                if (superUserInDb == null)
                {
                    await _userManager.CreateAsync(superUser, "Password@123");
                    var result = await _userManager.AddToRoleAsync(superUser, "Super Admin");
                }

            }).GetAwaiter().GetResult();
        }

        //private void AddBasicUser()
        //{
        //    Task.Run(async () =>
        //    {
        //        //Check if Role Exists
        //        var basicRole = new ApplicationRole(RoleConstants.BasicRole, "Basic role with default permissions");
        //        var basicRoleInDb = await _roleManager.FindByNameAsync(RoleConstants.BasicRole);
        //        if (basicRoleInDb == null)
        //        {
        //            await _roleManager.CreateAsync(basicRole);
        //            _logger.LogInformation("Seeded Basic Role.");
        //        }
        //        //Check if User Exists
        //        var basicUser = new ApplicationUser
        //        {
        //            FirstName = "John",
        //            LastName = "Doe",
        //            Email = "john@blazorhero.com",
        //            UserName = "johndoe",
        //            EmailConfirmed = true,
        //            PhoneNumberConfirmed = true,
        //            CreatedOn = DateTime.Now,
        //            IsActive = true
        //        };
        //        var basicUserInDb = await _userManager.FindByEmailAsync(basicUser.Email);
        //        if (basicUserInDb == null)
        //        {
        //            await _userManager.CreateAsync(basicUser, UserConstants.DefaultPassword);
        //            await _userManager.AddToRoleAsync(basicUser, RoleConstants.BasicRole);
        //            _logger.LogInformation("Seeded User with Basic Role.");
        //        }
        //    }).GetAwaiter().GetResult();
        //}
    }
}