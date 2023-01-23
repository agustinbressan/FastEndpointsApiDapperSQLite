using ClientsAgenda.Models;
using ClientsAgenda.Repositories;

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

        // TODO: Implement mapper
        return clients.Select(x => new Client
        {
            Id = Guid.Parse(x.Id),
            FirstName = x.FirstName,
            LastName = x.LastName,
            Email = x.Email,
            Phone = x.Phone
        });
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

        // TODO: Implement mapper -> this will resolve the null return code smell 
        return clientDto is not null ? new Client
        {
            Id = Guid.Parse(clientDto.Id),
            FirstName = clientDto.FirstName,
            LastName = clientDto.LastName,
            Email = clientDto.Email,
            Phone = clientDto.Phone
        } : null;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        return await _clientRepository.DeleteAsync(id);
    }
}