using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class ClientsController : ControllerBase
{
    private readonly ClientService _clientService;

    public ClientsController()
    {
        _clientService = new ClientService();
    }

    [HttpGet("allClients")]
    public ActionResult<List<ClientDto>> GetClients()
    {
        var clients = _clientService.GetAllClients();
        var clientDtos = clients.Select(c => new ClientDto
        {
            Id = c.Id,
            IdentityCard = c.IdentityCard,
            Name = c.Name,
            LastName = c.LastName,
            Email = c.Email,
            Phone = c.Phone
        }).ToList();

        return Ok(clientDtos);
    }

    [HttpGet("{identityCard}")]
    public ActionResult<ClientDto> GetCustomerById(string identityCard)
    {
        var customer = _clientService.GetClientByIdentityCard(identityCard);
        if (customer == null)
        {
            return NotFound(new { message = "El cliente no se encuentra en la base de datos.", status = 404 });
        }
        return Ok(customer);
    }
}