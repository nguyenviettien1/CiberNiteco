using System;

namespace CiberNiteco.Entities.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public decimal Amount { get; set; }
        public Product Product { get; set; }
        public Customer Customer { get; set; }
        public DateTime OrderDate { get; set; }
    }
}