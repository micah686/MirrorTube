using Npgsql;

namespace MirrorTube.API.Database
{
    public class DbHelper
    {
        private const string DB_NAME = "mirrortubedb";
        public static async Task CreateInitialDb()
        {
            try
            {              
                using (var dataSource = NpgsqlDataSource.Create(GetBaseConnectionString()))
                {
                    var dbQuery = dataSource.CreateCommand("SELECT datname FROM pg_database;");
                    var dbList = new List<string>();
                    var reader = await dbQuery.ExecuteReaderAsync();
                    while (reader.Read())
                    {
                        dbList.Add(reader.GetString(0));
                    }

                    if (!dbList.Contains(DB_NAME))
                    {
                        var cmd = dataSource.CreateCommand($"CREATE DATABASE {DB_NAME}");
                        await cmd.ExecuteScalarAsync();
                    }
                }

                using (var dataSource = NpgsqlDataSource.Create(GetConnectionString()))
                {
                    foreach (var name in Enum.GetNames(typeof(DatabaseSchema)))
                    {                        
                        var cmd = dataSource.CreateCommand($"CREATE SCHEMA IF NOT EXISTS {name}");
                        await cmd.ExecuteScalarAsync();
                    }                                        
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }            
        }

        private static string GetBaseConnectionString()
        {
            return "Host=localhost;Username=postgres;Password=123456;Include Error Detail=true;";
        }

        public static string GetConnectionString()
        {
            return $"Host=localhost;Username=postgres;Password=123456;Database={DB_NAME}";
        }
    }

    public enum DatabaseSchema
    {
        userdata,
        identity
    }
}
