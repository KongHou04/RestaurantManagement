using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DTO
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }

        [Required]
        public double UnitPrice { get; set; }

        [Required]
        [Column(TypeName = "Bit")]
        public bool Status { get; set; }

        [MaxLength(255)]
        public string? Image { get; set; }

        [MaxLength(255)]
        public string? Description { get; set; }

        public int? CategoryID { get; set; }


        public Category? Category { get; set; }
        public ICollection<ProductOrderDetails>? ProductOrderDetails { get; set; }


    }
}
