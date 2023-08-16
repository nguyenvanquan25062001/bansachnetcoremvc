using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace banhang.Models
{
    public class sanpham
    {
        [Key]
        public int  Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public string? ImageUrl { get; set; }
        public int? Quantity { get; set; }
        [ForeignKey("Categoty")]
        public int CategoryId { get; set; }
        public virtual Category? Category { get; set; } 

    }
}
