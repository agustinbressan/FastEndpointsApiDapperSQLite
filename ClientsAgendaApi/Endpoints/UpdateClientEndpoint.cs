using ClientsAgenda.Contracts.Requests;
using ClientsAgenda.Contracts.Responses;
using ClientsAgenda.Models;
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
        // TODO: Implement mapper
        var client = new Client
        {
            Id = request.Id,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Phone = request.Phone
        };
        await _clientService.UpdateAsync(client);
        
        await SendOkAsync(new ClientResponse {
            Id = client.Id,
            FirstName = client.FirstName,
            LastName = client.LastName,
            Email = client.Email,
            Phone = client.Phone
        }, ct);
    } 
}