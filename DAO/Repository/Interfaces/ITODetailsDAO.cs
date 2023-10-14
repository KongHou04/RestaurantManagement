using DAO.Repository.Interfaces.Actions;
using DTO;

namespace DAO.Repository.Interfaces
{
    public interface ITODetailsDAO : IAction<TableOrderDetails, int>, IFKEntityGetter<TableOrderDetails, Order>, IActionAddnReturn<TableOrderDetails>
    , IFK2EntityGetter<TableOrderDetails, Order, Table>
    {

    }
}