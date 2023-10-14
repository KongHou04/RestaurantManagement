using System.Threading.Tasks;

namespace DAO.Repository.Interfaces.Actions
{
    public interface IAction <T, Y>
    {
        public Task<List<T>> GetAll();

        public Task<T?> GetByID(Y id); 
        
        public Task<bool> Add(T entity);

        public Task<bool> Update(T entity, Y id);

        public Task<bool> Remove(Y id);

    }
}