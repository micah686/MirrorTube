using Npgsql;

namespace MirrorTube.API.Database
{
    public class InitDatabase
    {
        private const string DB_NAME = "MirrorTubeDb";
        public static async Task CreateDbAndSchema(string schemaName)
        {
            try
            {
                schemaName = schemaName.ToLower();
                var connectionString = "Host=localhost;Username=postgres;Password=123456;"; //no database parameter
                using (var dataSource = NpgsqlDataSource.Create(connectionString))
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

                using (var dataSource = NpgsqlDataSource.Create(connectionString + $"Database={DB_NAME};"))
                {
                    var cmd = dataSource.CreateCommand($"CREATE SCHEMA IF NOT EXISTS {schemaName}");
                    await cmd.ExecuteScalarAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }            
        }

        public static string GetBaseConnectionString()
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
        UserData,
        Identity
    }
}
