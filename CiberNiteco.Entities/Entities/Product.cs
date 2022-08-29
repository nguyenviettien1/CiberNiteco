﻿namespace CiberNiteco.Entities.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public decimal Quantity { get; set; }
        public Category Category { get; set; }
    }
}