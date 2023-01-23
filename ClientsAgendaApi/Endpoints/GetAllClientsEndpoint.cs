
using ClientsAgenda.Contracts.Responses;
using ClientsAgenda.Services;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;

namespace ClientsAgenda.Endpoints;

[HttpGet("clients"), AllowAnonymous]
public class GetAllClientsEndpoint : EndpointWithoutRequest
{
    private readonly IClientService _clientService;

    public GetAllClientsEndpoint(IClientService clientService)
    {
        _clientService = clientService;
    }

    public async override Task HandleAsync(CancellationToken ct)
    {
        var clients = await _clientService.GetAllAsync();

        // TODO: Implement mapper
        var clientsResponse = new GetAllClientsResponse
        {
            Clients = clients.Select(x => new ClientResponse
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                Phone = x.Phone
            }),
        };

        await SendOkAsync(clientsResponse, ct);
    }
}