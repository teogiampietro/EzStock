using Microsoft.AspNetCore.Identity;

namespace EzStock.Infrastructure.Context
{
    public class IdentityDataSeeder
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public IdentityDataSeeder(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task SeedAdminUser()
        {
            var adminRole = new IdentityRole
            {
                Id = "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                Name = "admin",
                NormalizedName = "admin".ToUpper()
            };
            await CreateRoleAsync(adminRole);

            var adminPassword = "P@ssword1";
            var adminUser = new IdentityUser
            {
                Id = "b8633e2d-a33b-45e6-8329-1958b3252bbd",
                UserName = "administrator",
                NormalizedUserName = "administrator".ToUpper(),
                Email = "administrator@ezstock.com",
                NormalizedEmail = "administrator@ezstock.com".ToUpper(),
                EmailConfirmed = true,
            };
            await CreateUserAsync(adminUser, adminPassword);

            var adminInRole = await _userManager.IsInRoleAsync(adminUser, adminRole.Name);
            if (!adminInRole)
                await _userManager.AddToRoleAsync(adminUser, adminRole.Name);
        }

        private async Task CreateRoleAsync(IdentityRole role)
        {
            var exits = await _roleManager.RoleExistsAsync(role.Name);
            if (!exits)
                await _roleManager.CreateAsync(role);
        }

        private async Task CreateUserAsync(IdentityUser user, string password)
        {
            var exists = await _userManager.FindByEmailAsync(user.Email);
            if (exists == null)
                await _userManager.CreateAsync(user, password);
        }
    }
}
