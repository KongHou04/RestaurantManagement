using System.Threading.Tasks;

namespace DAO.Repository.Interfaces.Actions
{
    public interface IAction <T, Y>
    {
        public Task<List<T>> GetAll();

        public Task<T?> GetByID(Y id); 
        
        public Task<string> Add(T obj);

        public Task<string> Update(T obj, Y id);

        public Task<string> Remove(Y id);

    }
}