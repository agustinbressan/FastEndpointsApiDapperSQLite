namespace ClientsAgenda.Contracts.Responses;

public class ClientResponse
{
    public Guid Id { get; init; }

    public string FirstName { get; init; } = default!;

    public string LastName { get; init; } = default!;

    public string FullName { get { return $"{FirstName}, {LastName}"; } }

    public string Email { get; init; } = default!;

    public string Phone { get; init; } = default!;
}