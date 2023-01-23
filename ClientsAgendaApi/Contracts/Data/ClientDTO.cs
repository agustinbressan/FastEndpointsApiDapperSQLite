namespace ClientsAgenda.Contracts.Data;

public class ClientDTO
{
    public string Id { get; init; } = default!;

    public string FirstName { get; init; } = default!;

    public string LastName { get; init; } = default!;

    public string Email { get; init; } = default!;

    public string Phone { get; init; } = default!;
}