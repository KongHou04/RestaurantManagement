using DAO.Repository.Interfaces.Actions;
using DTO;

namespace DAO.Repository.Interfaces
{
    public interface IAccountDAO : IAction<Account, string>, INameSearcher<Account>
    {
    }

}
