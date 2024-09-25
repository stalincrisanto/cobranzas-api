using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class PaymentController : ControllerBase
{
    private readonly PaymentService _paymentService;

    public PaymentController()
    {
        _paymentService = new PaymentService();
    }

    [HttpPost("register")]
    public ActionResult<HttpResponseMessage> RegisterPaymentIntent([FromBody] PaymentIntentModel paymentIntent)
    {
        if (paymentIntent == null)
        {
            return BadRequest("La intención de pago no puede ser nula.");
        }

        var response = _paymentService.RegisterPaymentIntent(paymentIntent);
        return Ok(response);
    }
}