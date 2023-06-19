using Hangfire;
using Hangfire.Dashboard;
using Hangfire.PostgreSql;
using Microsoft.EntityFrameworkCore;
using MirrorTube.API.Database;
using MirrorTube.API.Database.UserData;
using MirrorTube.API.Database.UserData.MapperProfiles;
using MirrorTube.API.Database.UserData.Triggers;
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
            //builder.Services.AddDbContext<UserDataContext>(options =>
            //    options.UseNpgsql(DbHelper.GetConnectionString(),
            //    x => x.MigrationsHistoryTable("__CustomMigrations", DatabaseSchema.userdata.ToString())
            //    ));;

            builder.Services.AddDbContext<UserDataContext>(options =>
            {
                options.UseNpgsql(DbHelper.GetConnectionString(), x =>
                {
                    x.MigrationsHistoryTable("__CustomMigration", DatabaseSchema.userdata.ToString());
                });
                options.UseTriggers(t =>
                {
                    t.AddTrigger<TestTrigger>();
                });
            });





            //Hangfire
            builder.Services.AddHangfire(configuration =>
            {
                configuration.UsePostgreSqlStorage(DbHelper.GetConnectionString());
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
