using BUS.Models;
using BUS.Repository.Interfaces.Setters;
using DAO.Repository.Interfaces;
using DTO;

namespace BUS.Repository.Implements.Getters
{
    public class TableOrderGetter : ITableOrderGetter
    {
        ITableDAO _tableDAO { get; set; }
        ITODetailsDAO _toDetailsDAO { get; set; }
        IOrderDAO _orderDAO { get; set; }

        public TableOrderGetter(ITableDAO tableDAO, ITODetailsDAO toDetailsDAO, IOrderDAO orderDAO)
        {
            _tableDAO = tableDAO;
            _toDetailsDAO = toDetailsDAO;
            _orderDAO = orderDAO;
        }

        public async Task<List<TableOrder>> GetTableOrders()
        {
            List<TableOrder> tableOrders = new List<TableOrder>();
            List<Table> tables = await _tableDAO.GetAll();
            tables.ForEach(async (table) => {
                int? orderID = await _toDetailsDAO.GetOrderID(table.ID);
                double? total = (orderID == null)? null : await _orderDAO.GetTotal((int)orderID);
                tableOrders.Add(new TableOrder(table, orderID, total));
            });
            return tableOrders;
        }
    }
}


