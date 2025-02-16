using DataAccess.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Service
{
    public static class DatabaseInitialization
    {
        public static async Task SeedDatabaseAsync(IServiceProvider serviceProvider)
        {
            //in case i needed to seed database in the future
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<QuizContext>();
            await context.Database.MigrateAsync();

            await SeedRolesAsync(scope.ServiceProvider);
        }

        public static async Task SeedRolesAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            string[] roles = { "Admin", "User", "Teacher" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }
    }
}
