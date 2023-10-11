using DAO.Repository.Interfaces.Actions;
using DTO;

namespace DAO.Repository.Interfaces
{
    public interface IRegionDAO : IAction <Region, int>, INameSearcher<Region>
    {
    }
    
}


