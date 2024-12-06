using Identity.Constants;
using Identity.Entities;
using Microsoft.AspNetCore.Identity;
namespace Identity
{
    public class DbInitializer
    {
        public static void Seed(UserManager<User> userManager,RoleManager<IdentityRole> roleManager)
        {
            AddRoles(roleManager);
            AddAdmin(userManager, roleManager);

        }
        private static void AddRoles(RoleManager<IdentityRole> roleManager)
        {
            foreach (var role in Enum.GetValues<UserRoles>())
            {
                if (!roleManager.RoleExistsAsync(role.ToString()).Result)
                {
                    roleManager.CreateAsync(new IdentityRole
                    {
                        Name = role.ToString()
                    });

                }

            }
        }
        private static void AddAdmin(UserManager<User> userManager,RoleManager<IdentityRole> roleManager)
        {
            if (userManager.FindByEmailAsync("admin@app.com").Result is null)
            {
                var user = new User
                {
                    Email = "admin@app.com",
                    City = "Baku",
                    Country = "Azerbaijan",
                    UserName = "admin@app.com"
                };
                var result = userManager.CreateAsync(user, "Admin123!").Result;
                if (!result.Succeeded)
                {
                    throw new Exception("Couldn't add Admin");
                }
                var role = roleManager.FindByNameAsync("Admin").Result;
                if (role.Name is null)
                {
                    throw new Exception("The Role Admin not found!");
                }
                var addRoleResult = userManager.AddToRoleAsync(user, role.Name).Result;

                if (!addRoleResult.Succeeded)
                    throw new Exception("Couldn't add Admin role to User");

            }






        }
    }
}
