using DAO.Repository.Interfaces.Actions;
using DTO;

namespace DAO.Repository.Interfaces
{
    public interface ICustomerDAO : IAction<Customer, int>, INameSearcher<Customer>
    {
    }
}

