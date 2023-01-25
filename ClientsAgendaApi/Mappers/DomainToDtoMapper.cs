using ClientsAgenda.Contracts.Data;
using ClientsAgenda.Models;

namespace ClientsAgenda.Mappers;

public static class DomainToDtoMapper
{
    public static ClientDTO ToClientDto(this Client client)
    {
        return new ClientDTO
        {
            Id = client.Id.ToString(),
            FirstName = client.FirstName,
            LastName = client.LastName,
            Email = client.Email,
            Phone = client.Phone
        };
    }
}