using ClientsAgenda.Contracts.Data;
using ClientsAgenda.Models;

namespace ClientsAgenda.Mappers;

public static class DtoToDomainMapper
{
    public static Client ToClient(this ClientDTO dto)
    {
        return new Client
        {
            Id = Guid.Parse(dto.Id),
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            Phone = dto.Phone
        };
    }
}