using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO
{
    [Table("Bill")]
    public class Bill
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string? CustomerName { get; set; }

        [Required]
        public double Total { get; set; }

        [Required]
        public DateTime BillTime { get; set; }

        [MaxLength(255)]
        public string? Description { get; set; }

        public int OrderID { get; set; }


        public Order? Order { get; set; }

    }
}
