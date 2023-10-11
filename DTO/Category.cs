using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DTO
{
    [Table("Category")]
    public class Category
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }

        [Required]
        [Column(TypeName = "Bit")]
        public bool Status { get; set; }

        [MaxLength(255)]
        public string? Description { get; set; }

        public ICollection<Product>? Products { get; set; }

    }
}