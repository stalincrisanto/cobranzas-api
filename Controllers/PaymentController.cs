using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class PaymentController : ControllerBase
{
    private readonly PaymentService _paymentService;
    private ClientService _clientService;

    public PaymentController()
    {
        _paymentService = new PaymentService();
        _clientService = new ClientService();
    }

    [HttpPost("register")]
    public ActionResult<HttpResponseMessage> RegisterPaymentIntent([FromBody] PaymentIntentModel paymentIntent)
    {
        var client = _clientService.GetClientByIdentityCard(paymentIntent.IdentityCard);
         Console.WriteLine("Payment Intent: " + client);
        if (paymentIntent == null)
        {
            return BadRequest("La intención de pago no puede ser nula.");
        }

        if (client.Debt.ExpiredDays < 120)
        {
            return BadRequest("El cliente no es elegible para registrar un convenio de pago");
        }

        var response = _paymentService.RegisterPaymentIntent(paymentIntent);
        return Ok(response);
    }
}