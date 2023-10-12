using System.Threading.Tasks;

namespace DAO.Repository.Interfaces.Actions
{
    public interface IAction <T, Y>
    {
        public Task<List<T>> GetAll();

        public Task<T?> GetByID(Y id); 
        
        public Task<bool> Add(T obj);

        public Task<bool> Update(T obj, Y id);

        public Task<bool> Remove(Y id);

    }
}