global using MirrorTube.Common;
using Hangfire;
using Hangfire.Dashboard;
using Hangfire.PostgreSql;
using Microsoft.EntityFrameworkCore;
using MirrorTube.API.Database.UserData;
using MirrorTube.API.Interfaces;
using MirrorTube.API.Services;

namespace MirrorTube.API
{
    public class Program
    {
        public static string BasePath { get; } = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory) ?? "";
        
        public static void Main(string[] args)
        {            
            
            StartupChecks.RunStartupChecks();
            
            var builder = WebApplication.CreateBuilder(args);
            var app = BuilderServices.ConfigureServices(builder);

            #region App
            //var app = builder.Build();

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