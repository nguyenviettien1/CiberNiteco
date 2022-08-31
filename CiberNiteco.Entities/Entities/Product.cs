using System.ComponentModel.DataAnnotations.Schema;

namespace CiberNiteco.Entities.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal Price { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal Quantity { get; set; }
        public Category Category { get; set; }
    }
}