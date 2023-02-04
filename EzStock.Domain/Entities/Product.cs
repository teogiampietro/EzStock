using System.ComponentModel.DataAnnotations;

namespace EzStock.Domain.Entities
{
    public class Product
    {
        [Key]
        public int IdProduct { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public double Price { get; set; }
    }
}
