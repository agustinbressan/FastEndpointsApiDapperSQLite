using ClientsAgenda.Contracts.Requests;
using ClientsAgenda.Models;

namespace ClientsAgenda.Mappers;
 
public static class RequestToDomainMapper
{
    public static Client ToClient(this CreateClientRequest request)
    {
        return new Client
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Phone = request.Phone
        };
    }

    public static Client ToClient(this UpdateClientRequest request)
    {
        return new Client
        {
            Id = request.Id,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Phone = request.Phone
        };
    }
}