using System.ComponentModel.DataAnnotations;

namespace OrderAPI.Model
{
    public class ProductType
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Width { get; set; }
    }
}
