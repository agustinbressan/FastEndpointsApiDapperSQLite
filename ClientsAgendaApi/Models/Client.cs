namespace ClientsAgenda.Models;

public class Client
{
    public Guid Id { get; init; } = Guid.NewGuid();

    public string FirstName { get; init; } = default!;

    public string LastName { get; init; } = default!;

    public string Email { get; set; } = default!;

    public string Phone { get; set; } = default!;
}