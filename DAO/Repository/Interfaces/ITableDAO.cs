using DAO.Repository.Interfaces.Actions;
using DTO;

namespace DAO.Repository.Interfaces
{
    public interface ITableDAO : IAction<Table, int>, INameSearcher<Table>
    {
    }
}