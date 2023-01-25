using ClientsAgenda.Contracts.Responses;
using ClientsAgenda.Models;

namespace ClientsAgenda.Mappers;

public static class DomainToResponse
{
    public static ClientResponse ToClientResponse(this Client client)
    {
        return new ClientResponse
        {
            Id = client.Id,
            FirstName = client.FirstName,
            LastName = client.LastName,
            Email = client.Email,
            Phone = client.Phone
        };
    }
}