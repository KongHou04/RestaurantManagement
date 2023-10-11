using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO
{
    [Table("Order")]
    public class Order
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public DateTime OrderTime { get; set; }

        [Required]
        [Column(TypeName = "Bit")]
        public bool Status { get; set; }

        [MaxLength(255)]
        public string? Description { get; set; }

        [Required]
        public int EmployeeID { get; set; }

        [Required]
        public int CustomerID { get; set; }


        public Employee? Employee { get; set; } 
        public Customer? Customer { get; set; }
        public Bill? Bill { get; set; }
        public ICollection<TableOrderDetails>? TableOrderDetails { get; set; }

    }
}
