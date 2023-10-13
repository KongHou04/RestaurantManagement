using DAO.Repository.Interfaces.Actions;
using DTO;

namespace DAO.Repository.Interfaces
{
    public interface ITODetailsDAO : IAction<TableOrderDetails, int>, IFKEntityGetter<TableOrderDetails, Order>
    {
    }

}