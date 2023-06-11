using FluentFTP;
using MirrorTube.Common.Models.Database.UserData;
using ServiceStack.OrmLite;

namespace MirrorTube.API.Database
{
    public class InitDatabase
    {
        internal static void Init(IConfigurationRoot appConfig)
        {
            var dbFactory = new OrmLiteConnectionFactory(appConfig.GetConnectionString("DatabaseConnection"), PostgreSqlDialect.Provider);

            using (var db = dbFactory.Open())
            {
                db.DropAndCreateTable<VideoInfoHistory>();
            }
        }
    }
}
