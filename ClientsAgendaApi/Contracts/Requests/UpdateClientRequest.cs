namespace ClientsAgenda.Contracts.Requests;

public class UpdateClientRequest
{
    public Guid Id { get; init; }

    public string FirstName { get; init; } = default!;

    public string LastName { get; init; } = default!;

    public string Email { get; init; } = default!;

    public string Phone { get; init; } = default!;
}