using ClientsAgenda.Contracts.Requests;
using ClientsAgenda.Contracts.Responses;
using ClientsAgenda.Mappers;
using ClientsAgenda.Services;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;

namespace ClientsAgenda.Endpoints;

[HttpGet("clients/{id:guid}"), AllowAnonymous]
public class GetClientEndpoint : Endpoint<GetClientRequest, ClientResponse>
{
    private readonly IClientService _clientService;

    public GetClientEndpoint(IClientService clientService)
    {
        _clientService = clientService;
    }

    public async override Task HandleAsync(GetClientRequest request, CancellationToken ct)
    {
        var client = await _clientService.GetAsync(request.Id);

        if (client is null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        await SendOkAsync(client.ToClientResponse(), ct);
    }
}