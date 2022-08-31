using System.ComponentModel.DataAnnotations.Schema;

namespace CiberNiteco.Entities.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }
        public string Description { get; set; }
        public decimal Quantity { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public Category Category { get; set; }
    }
}