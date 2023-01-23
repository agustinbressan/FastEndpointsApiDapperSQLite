namespace ClientsAgenda.Contracts.Responses;

public class GetAllClientsResponse
{
    public IEnumerable<ClientResponse> Clients { get; init; } = Enumerable.Empty<ClientResponse>();
}