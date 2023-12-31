using DAO.Repository.Interfaces.Actions;
using DTO;

namespace DAO.Repository.Interfaces
{
    public interface IEmployeeDAO : IAction<Employee, int>, INameSearcher<Employee>
    {
    }
}
