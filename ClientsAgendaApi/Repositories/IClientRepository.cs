using ClientsAgenda.Contracts.Data;
using ClientsAgenda.Models;

namespace ClientsAgenda.Repositories;

public interface IClientRepository
{
    Task<IEnumerable<ClientDTO>> GetAllAsync();

    Task<bool> CreateAsync(Client client);

    Task<bool> UpdateAsync(Client client);

    Task<ClientDTO?> GetAsync(Guid id);
    
    Task<bool> DeleteAsync(Guid id);
}