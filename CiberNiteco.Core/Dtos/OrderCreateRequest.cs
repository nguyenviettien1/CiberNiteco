using System;

namespace CiberNiteco.Core.Dtos
{
    public class OrderCreateRequest
    {
        public string OrderName { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Amount { get; set; }
    }
}