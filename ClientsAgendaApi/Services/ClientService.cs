using ClientsAgenda.Models;
using ClientsAgenda.Repositories;
using ClientsAgenda.Mappers;

namespace ClientsAgenda.Services;

public class ClientService : IClientService
{
    private readonly IClientRepository _clientRepository;

    public ClientService(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }

    public async Task<IEnumerable<Client>> GetAllAsync()
    {
        var clients = await _clientRepository.GetAllAsync();

        return clients.Select(x => x.ToClient());
    }

    public async Task<bool> CreateAsync(Client client)
    {
        return await _clientRepository.CreateAsync(client);
    }

    public async Task<bool> UpdateAsync(Client client)
    {
        return await _clientRepository.UpdateAsync(client);
    }

    public async Task<Client?> GetAsync(Guid id)
    {
        var clientDto = await _clientRepository.GetAsync(id);

        return clientDto?.ToClient();
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        return await _clientRepository.DeleteAsync(id);
    }
}