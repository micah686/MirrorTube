using Hangfire;
using Hangfire.Dashboard;
using Hangfire.PostgreSql;
using Microsoft.EntityFrameworkCore;
using MirrorTube.API.Database;
using MirrorTube.API.Database.UserData;
using MirrorTube.API.Interfaces;
using MirrorTube.API.Services;

namespace MirrorTube.API
{
    public class BuilderServices
    {
        public static WebApplication ConfigureServices(WebApplicationBuilder builder)
        {
            var appConfig = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //AutoMapper
            builder.Services.AddAutoMapper(m =>
            {
                m.AddProfile<UserDataProfile>();
            });

            //EF Core
            builder.Services.AddDbContext<UserDataContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("DatabaseConnection"),
                x => x.MigrationsHistoryTable("__CustomMigrations", DatabaseSchema.UserData.ToString())));


            //Hangfire
            builder.Services.AddHangfire(configuration =>
            {
                configuration.UsePostgreSqlStorage(appConfig.GetConnectionString("DatabaseConnection"));
                configuration.UseSimpleAssemblyNameTypeSerializer();
                configuration.UseRecommendedSerializerSettings();
                configuration.UseDashboardMetrics(new DashboardMetric[]
                    { DashboardMetrics.ScheduledCount, DashboardMetrics.ProcessingCount, DashboardMetrics.EnqueuedAndQueueCount, DashboardMetrics.SucceededCount, DashboardMetrics.FailedCount });
            });
            builder.Services.AddHangfireServer();


            builder.Services.AddTransient<IStorageService, StorageService>();
            builder.Services.AddTransient<IDownloadService, DownloadService>();
            builder.Services.AddTransient<IVideoDbWriterService, VideoDbWriterService>();
            
            return builder.Build();
        }
    }
}
