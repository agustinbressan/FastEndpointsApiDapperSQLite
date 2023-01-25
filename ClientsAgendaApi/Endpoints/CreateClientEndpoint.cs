using ClientsAgenda.Contracts.Requests;
using ClientsAgenda.Contracts.Responses;
using ClientsAgenda.Mappers;
using ClientsAgenda.Services;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;

namespace ClientsAgenda.Endpoints;

[HttpPost("clients"), AllowAnonymous]
public class CreateClientEndpoint : Endpoint<CreateClientRequest, ClientResponse>
{
    private readonly IClientService _clientService;

    public CreateClientEndpoint(IClientService clientService)
    {
        _clientService = clientService;
    }

    public async override Task HandleAsync(CreateClientRequest request, CancellationToken ct)
    {
        var client = request.ToClient();
        await _clientService.CreateAsync(client);
        
        await SendOkAsync(client.ToClientResponse(), ct);
    }
}