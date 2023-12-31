using DAO.Repository.Interfaces.Actions;
using DTO;

namespace DAO.Repository.Interfaces
{
    public interface IPODetailsDAO : IAction<ProductOrderDetails, int>, IFKEntityGetter<ProductOrderDetails, TableOrderDetails>
    {
    }
}