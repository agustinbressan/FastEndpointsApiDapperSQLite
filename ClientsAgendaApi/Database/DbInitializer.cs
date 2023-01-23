using Dapper;

namespace ClientsAgenda.Database;

public class DbInitializer
{
    private readonly IDbConnectionFactory _connectionFactory;

    public DbInitializer(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task InitializeAsync()
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();
        
        await connection.ExecuteAsync(@"CREATE TABLE IF NOT EXISTS Clients (
        Id CHAR(36) PRIMARY KEY, 
        FirstName TEXT NOT NULL,
        LastName TEXT NOT NULL,
        Email TEXT NOT NULL,
        Phone TEXT NOT NULL)");
    }
}