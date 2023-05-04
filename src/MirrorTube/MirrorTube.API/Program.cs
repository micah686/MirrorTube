global using MirrorTube.Common;
using Hangfire;
using Hangfire.Dashboard;
using Hangfire.Storage.SQLite;
using MirrorTube.API.Interfaces;
using MirrorTube.API.Services;
using ServiceStack;

namespace MirrorTube.API
{
    public class Program
    {
        public static string BasePath { get; } = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory) ?? "";
        
        public static void Main(string[] args)
        {            
            var appConfig = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            ServiceStack.Licensing.RegisterLicense(appConfig["servicestack:license"]);

            StartupChecks.RunStartupChecks();
            
            #region Builder
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


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


            builder.Services.AddTransient<IStorageService, StorageService>();
            builder.Services.AddTransient<IDownloadService, DownloadService>();
            builder.Services.AddTransient<IVideoDbWriterService, VideoDbWriterService>();

            //builder.Services.AddAutoMapper(m =>
            //{
            //    m.AddProfile<MapperProfile>();
            //});
            


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