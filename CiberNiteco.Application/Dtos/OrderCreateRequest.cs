using System;

namespace CiberNiteco.Application.Dtos
{
    public class OrderCreateRequest
    {
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public decimal Amount { get; set; }
    }
}