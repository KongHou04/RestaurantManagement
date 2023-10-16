using DTO;

namespace BUS.Models
{
    public class TableOrder
    {
        public Table Table { get; set; }
        public int? OrderID { get; set;}

        public double? Total { get; set; }

        public TableOrder(Table table, int? orderID = null, double? total = null)
        {
            Table = table;
            OrderID = orderID;
            Total = total;
        }

    }
}


