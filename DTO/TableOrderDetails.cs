using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO
{
    [Table("TableOrderDetails")]
    public class TableOrderDetails
    {
        [Key]
        public int ID { get; set; }

        [MaxLength(255)]
        public string? Description { get; set; }

        [Required]
        public int OrderID { get; set; }

        public int TableID { get; set; }


        public Order? Order { get; set; }
        public Table? Table { get; set; }
        public ICollection<ProductOrderDetails>? ProductOrderDetails { get; set; }

    }
}
