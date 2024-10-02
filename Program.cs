using Microsoft.EntityFrameworkCore;
using Services.Services;

namespace Services
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSingleton<IServiceUsers, ServiceUsers>();
            builder.Services.AddDbContext<UserContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            app.UseRouting();
            app.MapControllers();

            app.Run();

        }
    }
}