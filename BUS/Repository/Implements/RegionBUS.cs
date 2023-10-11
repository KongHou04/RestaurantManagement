using System.Buffers;
using BUS.Handler;
using BUS.Repository.Interfaces;
using DAO.Repository.Interfaces;
using DTO;

namespace BUS.Repository.Implements
{
    public class RegionBUS : IRegionBUS
    {
        IRegionDAO _regionDAO;

        public RegionBUS(IRegionDAO regionDAO)
        {
            _regionDAO = regionDAO;
        }

        public async Task<string> AddNewRegion(string name, bool status, string description)
        {
            Region? region = DataCreator.GetRegion(name, status, description);
            if (region == null)
                return "Data is invalid";
            return await _regionDAO.Add(region);
        }

        public async Task<string> UpdateRegion(string name, bool status, string description, int id)
        {
            Region? region = DataCreator.GetRegion(name, status, description);
            if (region == null)
                return "Data is invalid";
            return await _regionDAO.Update(region, id);
        }

    }
}