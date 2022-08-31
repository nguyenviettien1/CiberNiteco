using System;

namespace CiberNiteco.Core.Dtos
{
    public class OrderCreateRequest
    {
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public decimal Amount { get; set; }
    }
}