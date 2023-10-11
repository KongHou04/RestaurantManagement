using DTO;

namespace BUS.Repository.Interfaces
{
    public interface ITableBUS
    {
        public Task<List<Table>> GetTables();
    }
}