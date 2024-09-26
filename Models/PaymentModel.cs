public class PaymentIntentModel
{
    public string Id { get; set; }
    public string ClientId { get; set; }
    public decimal Amount { get; set; }
    public DateTime? Deadline { get; set; }
}