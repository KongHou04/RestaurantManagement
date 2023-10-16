using BUS.Repository.Interfaces.Getters;
using DAO.Repository.Interfaces;
using DTO;

namespace BUS.Repository.Implements.Getters
{
    public class TableGetter : ITableGetter
    {
        ITableDAO _tableDAO { get; set; }
        public TableGetter(ITableDAO tableDAO)
        {
            _tableDAO = tableDAO;
        }
        public async Task<List<Table>> GetTables()
        {
            return await _tableDAO.GetAll();
        }
    }
}