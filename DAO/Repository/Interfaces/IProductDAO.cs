using DAO.Repository.Interfaces.Actions;
using DTO;

namespace DAO.Repository.Interfaces
{
    public interface IProductDAO : IAction<Product, int>, INameSearcher<Product>
    {
    }

}