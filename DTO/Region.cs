using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO
{
    [Table("Region")]
    public class Region
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


        public ICollection<Table>? Tables { get; set; }

    }
}
