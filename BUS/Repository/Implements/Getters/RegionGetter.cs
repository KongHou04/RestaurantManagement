using BUS.Repository.Interfaces.Getters;
using DAO.Repository.Interfaces;
using DTO;

namespace BUS.Repository.Implements.Getters
{
    public class RegionGetter : IRegionGetter
    {
        IRegionDAO _regionDAO { get; set; }
        public RegionGetter(IRegionDAO regionDAO)
        {
            _regionDAO = regionDAO;
        }
        public async Task<List<Region>> GetRegions()
        {
            return await _regionDAO.GetAll();
        }
    }
}