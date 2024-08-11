using Microsoft.Data.Sqlite;

public class DatabaseService
{
    private readonly string _connectionString;

    public DatabaseService()
    {
        // Connection string points to your .db file
        _connectionString = "Data Source=database.db";
    }

    public void TestConnection()
    {
        try
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();
            Console.WriteLine("Connection to SQLite database established.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error connecting to SQLite database: {ex.Message}");
        }
    }
}
