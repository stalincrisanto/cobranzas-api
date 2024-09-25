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

    [HttpGet ("allClients")]
    public ActionResult<List<ClientDto>> GetClients()
    {
        var clients = _clientService.GetAllClients();
        var clientDtos = clients.Select(c => new ClientDto
        {
            Id = c.Id,
            Name = c.Name,
            LastName = c.LastName,
            Email = c.Email
        }).ToList();

        return Ok(clientDtos);
    }

    [HttpGet("{idCard}")]
    public ActionResult<ClientDto> GetCustomerById(string idCard)
    {
        var customer = _clientService.GetCustomerByIdCard(idCard);
        if (customer == null)
        {
            return NotFound();
        }
        return Ok(customer);
    }
}