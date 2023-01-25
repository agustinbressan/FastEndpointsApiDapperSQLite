using ClientsAgenda.Contracts.Requests;
using ClientsAgenda.Contracts.Responses;
using ClientsAgenda.Mappers;
using ClientsAgenda.Services;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;

namespace ClientsAgenda.Endpoints;

[HttpPut("clients"), AllowAnonymous]
public class UpdateClientEndpoint : Endpoint<UpdateClientRequest, ClientResponse>
{
    private readonly IClientService _clientService;

    public UpdateClientEndpoint(IClientService clientService)
    {
        _clientService = clientService;
    }

    public async override Task HandleAsync(UpdateClientRequest request, CancellationToken ct)
    {
        var client = request.ToClient();
        await _clientService.UpdateAsync(client);
        
        await SendOkAsync(client.ToClientResponse(), ct);
    } 
}