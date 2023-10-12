using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DTO
{
    [Table("Table")]
    public class Table
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

        public int? RegionID { get; set; }


        public Region? Region { get; set; }
        public ICollection<TableOrderDetails>? TableOrderDetails { get; set; }

    }
}
