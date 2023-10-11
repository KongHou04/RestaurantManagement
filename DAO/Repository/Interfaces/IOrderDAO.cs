using DAO.Repository.Interfaces.Actions;
using DTO;

namespace DAO.Repository.Interfaces
{
    public interface IOrderDAO : IAction<Order, int>
    {
    }

}