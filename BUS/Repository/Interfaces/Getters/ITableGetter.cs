using DTO;

namespace BUS.Repository.Interfaces.Getters
{
    public interface ITableGetter
    {
        public Task<List<Table>> GetTables();
    }
}