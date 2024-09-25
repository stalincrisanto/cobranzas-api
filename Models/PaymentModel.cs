public class PaymentIntentModel
{
    public string Id { get; set; }
    public string ClientId { get; set; }
    public decimal Amount { get; set; }
    public string PaymentMethod { get; set; }
    public DateTime IntentDate { get; set; }
}