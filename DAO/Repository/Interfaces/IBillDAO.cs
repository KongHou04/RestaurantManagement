using DAO.Repository.Interfaces.Actions;
using DTO;

namespace DAO.Repository.Interfaces
{
    public interface IBillDAO : IAction<Bill, int>
    {
    }
}