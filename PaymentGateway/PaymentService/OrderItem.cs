
namespace PaymentService
{
    public class OrderItem
    {
        public string ProductId { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public Price Cost { get; set; }
    }
}
