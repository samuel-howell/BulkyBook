using BulkyBookWeb.Data;
using Microsoft.EntityFrameworkCore;

namespace BulkyBookWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer( //this ties in the connection string from appsettings and the applicationDbContext to the main program
                builder.Configuration.GetConnectionString("DefaultConnection") // from DefaultConnection block in appsettings.json
                ));
            //builder.Services.AddRazorPages().AddRazorRuntimeCompilation(); // allows runtime compilation on razor views. unecessary since newest version of hot reload was released. causes footer to break.
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }

        // project based on https://www.youtube.com/watch?v=hZ1DASYd9rk most recent stop - 1:54:55
    }
}