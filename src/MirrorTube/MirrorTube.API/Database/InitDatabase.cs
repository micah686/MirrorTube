using Npgsql;

namespace MirrorTube.API.Database
{
    public class InitDatabase
    {
        public static async Task CreateDbAndSchema(string dbName, string schemaName)
        {
            try
            {
                dbName = dbName.ToLower();
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

                    if (!dbList.Contains(dbName))
                    {
                        var cmd = dataSource.CreateCommand($"CREATE DATABASE {dbName}");
                        await cmd.ExecuteScalarAsync();
                    }
                }

                using (var dataSource = NpgsqlDataSource.Create(connectionString + $"Database={dbName};"))
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
    }
}
