global using MirrorTube.Common;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MirrorTube.API.Database;
using Hangfire;
using Hangfire.Dashboard;
using Hangfire.Storage.SQLite;
using MirrorTube.API.Database.Identity;
using MirrorTube.API.Interfaces;
using MirrorTube.API.Services;
using MirrorTube.API.Database.UserData;

namespace MirrorTube.API
{
    public class Program
    {
        public static string BasePath { get; } = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory) ?? "";

        public static void Main(string[] args)
        {
            StartupChecks.RunStartupChecks();
            
            #region Builder
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //Identity
            builder.Services.AddDbContext<AppIdentityDbContext>(options =>
            {
                options.UseSqlite($"Data Source={Globals.DbIdentity}");
            });
            builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireDigit = false;                
            }).AddEntityFrameworkStores<AppIdentityDbContext>();

            //Hangfire
            builder.Services.AddHangfire(configuration =>
            {
                configuration.UseSQLiteStorage(Globals.DbHangfire);
                configuration.UseDarkModeSupportForDashboard();
                configuration.UseSimpleAssemblyNameTypeSerializer();
                configuration.UseRecommendedSerializerSettings();
                configuration.UseDashboardMetrics(new DashboardMetric[]
                    { DashboardMetrics.ScheduledCount, DashboardMetrics.ProcessingCount, DashboardMetrics.EnqueuedAndQueueCount, DashboardMetrics.SucceededCount, DashboardMetrics.FailedCount });
            });
            builder.Services.AddHangfireServer();

            builder.Services.AddDbContext<UserDatadbContext>(options =>
            {
                options.UseSqlite($"Data Source={Globals.DbMirrorTube}");
            });

            builder.Services.AddTransient<IStorageService, StorageService>();
            builder.Services.AddTransient<IDownloadService, DownloadService>();
            builder.Services.AddTransient<IVideoDbWriterService, VideoDbWriterService>();

            builder.Services.AddAutoMapper(m =>
            {
                m.AddProfile<MapperProfile>();
            });
            


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