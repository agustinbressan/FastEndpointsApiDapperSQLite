
using ClientsAgenda.Contracts.Responses;
using ClientsAgenda.Mappers;
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

        var clientsResponse = new GetAllClientsResponse
        {
            Clients = clients.Select(x => x.ToClientResponse()),
        };

        await SendOkAsync(clientsResponse, ct);
    }
}