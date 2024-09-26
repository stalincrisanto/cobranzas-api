public class ClientDto
{
    public required string Id { get; set; }
    public required string IdentityCard { get; set; }
    public required string Name { get; set; }
    public required string LastName { get; set; }
    public required string Phone { get; set; }
    public required string Email { get; set; }
    public DebtDetailsDto Debt { get; set; }
}