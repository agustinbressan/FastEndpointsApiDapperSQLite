using ClientsAgenda.Contracts.Requests;
using ClientsAgenda.Contracts.Responses;
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

        // TODO: Implement mapper
        var clientResponse = new ClientResponse
        {
            Id = client.Id,
            FirstName = client.FirstName,
            LastName = client.LastName,
            Email = client.Email,
            Phone = client.Phone
        };

        await SendOkAsync(clientResponse, ct);
    }
}