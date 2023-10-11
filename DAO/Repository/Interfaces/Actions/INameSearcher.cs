using System.Threading.Tasks;

namespace DAO.Repository.Interfaces.Actions
{
    public interface INameSearcher <T>
    {
        public Task<List<T>> GetByName(string name);
    }

}

