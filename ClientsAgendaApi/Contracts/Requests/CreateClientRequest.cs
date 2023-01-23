namespace ClientsAgenda.Contracts.Requests;

public class CreateClientRequest
{
    public string FirstName { get; init; } = default!;

    public string LastName { get; init; } = default!;

    public string Email { get; set; } = default!;

    public string Phone { get; set; } = default!;
}