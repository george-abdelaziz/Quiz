using DataAccess.Interface;
using DataAccess.Models;
using DataAccess.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Service;

namespace Frontend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddTransient<IEmailSender, DummyEmailSender>();

            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<QuizContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            //builder.Services.AddDefaultIdentity<AppUser>().AddEntityFrameworkStores<QuizContext>();
            builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequiredLength = 12;
            })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<QuizContext>()
                .AddDefaultTokenProviders();

            builder.Services.AddRazorPages();
            builder.Services.AddHttpClient();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();
            app.MapRazorPages();
            app.MapAreaControllerRoute(
                name: "admin",
                areaName: "Admin",
                pattern: "Admin/{controller=Dashboard}/{action=Index}/{id?}");


            app.Run();
        }
    }
}
