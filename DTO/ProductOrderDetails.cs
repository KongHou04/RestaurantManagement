using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO
{
    [Table("ProductOrderDetails")]
    public class ProductOrderDetails
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        [MaxLength(255)]
        public string? Description { get; set; }

        [Required]
        public int TableOrDtID { get; set; }

        [Required]
        public int ProductID { get; set; }


        public Product? Product { get; set; }
        public TableOrderDetails? TableOrderDetails { get; set; }


    }
}
