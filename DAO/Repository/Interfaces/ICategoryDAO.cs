using DAO.Repository.Interfaces.Actions;
using DTO;

namespace DAO.Repository.Interfaces
{
    public interface ICategoryDAO : IAction <Category, int>, INameSearcher<Category>
    {
    }
}