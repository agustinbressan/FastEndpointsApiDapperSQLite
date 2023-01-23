using ClientsAgenda.Models;

namespace ClientsAgenda.Services;

public interface IClientService
{
    Task<IEnumerable<Client>> GetAllAsync();

    Task<bool> CreateAsync(Client client);

    Task<bool> UpdateAsync(Client client);

    Task<Client?> GetAsync(Guid id);
    
    Task<bool> DeleteAsync(Guid id);
}