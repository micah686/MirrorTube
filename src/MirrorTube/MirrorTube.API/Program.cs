using Hangfire;
using Hangfire.Dashboard;
using Hangfire.Storage.SQLite;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MirrorTube.API.Database;

namespace MirrorTube.API
{
    public class Program
    {
        public static string BasePath { get; } = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory) ?? "";

        public static void Main(string[] args)
        {

            #region Builder
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //Identity
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlite($"Data Source={Path.Combine(BasePath, "Data.db")}");
            });
            builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireDigit = false;                
            }).AddEntityFrameworkStores<ApplicationDbContext>();

            //Hangfire
            GlobalConfiguration.Configuration.UseSQLiteStorage(Path.Combine(BasePath, "Hangfire.db"));
            builder.Services.AddHangfire(configuration =>
            {
                configuration.UseSQLiteStorage(Path.Combine(BasePath, "Hangfire.db"));
                configuration.UseDarkModeSupportForDashboard();
                configuration.UseSimpleAssemblyNameTypeSerializer();
                configuration.UseRecommendedSerializerSettings();
                configuration.UseDashboardMetrics(new DashboardMetric[]
                    { DashboardMetrics.ScheduledCount, DashboardMetrics.ProcessingCount, DashboardMetrics.EnqueuedAndQueueCount, DashboardMetrics.SucceededCount, DashboardMetrics.FailedCount });
            });
            builder.Services.AddHangfireServer();
            #endregion


            #region App
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(opts => opts.EnableTryItOutByDefault());
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();
            app.UseHangfireDashboard();

            app.Run();
            #endregion
        }
    }
}