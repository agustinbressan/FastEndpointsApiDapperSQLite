using ClientsAgenda.Contracts.Requests;
using ClientsAgenda.Contracts.Responses;
using ClientsAgenda.Models;
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
        // TODO: Implement mapper
        var client = new Client
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Phone = request.Phone
        };
        await _clientService.CreateAsync(client);
        
        await SendOkAsync(new ClientResponse {
            Id = client.Id,
            FirstName = client.FirstName,
            LastName = client.LastName,
            Email = client.Email,
            Phone = client.Phone
        }, ct);
    }
}