using System.Net;
using System.Text;
using System.Text.Json;

public class PaymentService
{
    public object RegisterPaymentIntent(PaymentIntentModel paymentIntent)
    {
        var responseMessage = new
        {
            Message = "Intención de pago registrada exitosamente.",
            PaymentIntent = paymentIntent
        };
        
        return responseMessage;
    }
}