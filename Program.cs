using Microsoft.EntityFrameworkCore;
using SoccerJerseyPass.Data;
using SoccerJerseyPass.Data.Services;

namespace SoccerJerseyPass
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddMvc();

            // Add services configuration

            builder.Services.AddScoped<IPlayersService, PlayersService>();

            // Add DbContext Configuration

            IConfiguration configuration = new ConfigurationBuilder()
           .AddJsonFile("appsettings.json")
           .AddEnvironmentVariables().Build();

            builder.Services.AddDbContext<AppDbContext>(optionsAction =>
            {
                optionsAction.UseSqlServer(configuration.GetConnectionString(name: "DefaultConnection"));
            });

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


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllerRoute(name: "default", pattern: "{controller=Soccer-Jerseys}/{action=Index}/{id?}");
            });

           
            // Seed database 

            AppDbInitializer.seed(app);

            app.Run();
        }
    }
}