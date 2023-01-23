using ClientsAgenda.Contracts.Data;
using ClientsAgenda.Database;
using ClientsAgenda.Models;
using Dapper;

namespace ClientsAgenda.Repositories;

public class ClientRepository : IClientRepository
{
    private readonly IDbConnectionFactory _connectionFactory;
    
    public ClientRepository(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<IEnumerable<ClientDTO>> GetAllAsync()
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();

        return await connection.QueryAsync<ClientDTO>(@"SELECT Id, FirstName, LastName, Email, Phone FROM Clients");
    }

    public async Task<bool> CreateAsync(Client client)
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();

        var rowsAffected = await connection.ExecuteAsync(@"
            INSERT INTO Clients
                (Id, FirstName, LastName, Email, Phone) 
            VALUES
                (@Id, @FirstName, @LastName, @Email, @Phone)",
            client);

        return rowsAffected > 0;
    }

    public async Task<bool> UpdateAsync(Client client)
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();

        var rowsAffected = await connection.ExecuteAsync(@"
            UPDATE Clients SET
                FirstName = @FirstName,
                LastName = @LastName,
                Email = @Email,
                Phone = @Phone
            WHERE
                Id = @Id",
            client);

        return rowsAffected > 0;
    }

    public async Task<ClientDTO?> GetAsync(Guid id)
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();

        return await connection.QuerySingleOrDefaultAsync<ClientDTO>(@"
            SELECT Id, FirstName, LastName, Email, Phone
            FROM Clients
            WHERE Id = @Id"
            , new { Id = id.ToString().ToUpper() });
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();

        var rowsAffected = await connection.ExecuteAsync(@"
            DELETE FROM Clients
            WHERE Id = @Id",
            new { Id = id.ToString().ToUpper() });

        return rowsAffected > 0;
    }
}