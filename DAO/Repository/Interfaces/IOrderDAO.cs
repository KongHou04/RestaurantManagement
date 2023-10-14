using Azure.Core;
using DAO.Repository.Interfaces.Actions;
using DTO;

namespace DAO.Repository.Interfaces
{
    public interface IOrderDAO : IAction<Order, int>, IActionAddnReturn<Order>
    {
        public Task<double> GetTotal(int id);

    }
}