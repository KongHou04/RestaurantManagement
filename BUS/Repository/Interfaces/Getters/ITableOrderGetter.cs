using BUS.Models;

namespace BUS.Repository.Interfaces.Setters
{
    public interface ITableOrderGetter
    {
        public Task<List<TableOrder>> GetTableOrders();
    }
}


