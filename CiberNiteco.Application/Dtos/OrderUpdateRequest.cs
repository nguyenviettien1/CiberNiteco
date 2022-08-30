namespace CiberNiteco.Application.Dtos
{
    public class OrderUpdateRequest
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public decimal Amount { get; set; }
    }
}