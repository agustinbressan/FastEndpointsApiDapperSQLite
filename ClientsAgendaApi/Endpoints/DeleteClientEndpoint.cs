using ClientsAgenda.Contracts.Requests;
using ClientsAgenda.Services;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;

namespace ClientsAgenda.Endpoints;

[HttpDelete("clients/{id:guid}"), AllowAnonymous]
public class DeleteClientEndpoint : Endpoint<DeleteClientRequest>
{
    private readonly IClientService _clientService;

    public DeleteClientEndpoint(IClientService clientService)
    {
        _clientService = clientService;
    }

    public async override Task HandleAsync(DeleteClientRequest request, CancellationToken ct)
    {
        var deleted = await _clientService.DeleteAsync(request.Id);

        if (!deleted)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        await SendOkAsync(new
        {
            Id = request.Id,
            deleted
        }, ct);
    }
}