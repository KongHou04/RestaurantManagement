using BUS.Handler;
using BUS.Repository.Interfaces.Setters;
using DAO.Repository.Interfaces;
using DTO;

namespace BUS.Repository.Implements.Setters
{
    public class RegionBUS : IRegionBUS
    {
        IRegionDAO _regionDAO;

        public RegionBUS(IRegionDAO regionDAO)
        {
            _regionDAO = regionDAO;
        }

        public async Task<string> AddRegion(string? name, bool status, string? description)
        {
            Region? region = DataCreator.GetRegion(name, status, description);
            if (region == null)
                return "Data is invalid";
            if (await _regionDAO.Add(region))
                return "Add new region successfully";
            return "Cannot add new region";
        }

        public async Task<string> UpdateRegion(string? name, bool status, string? description, int id)
        {
            Region? oldReg = await _regionDAO.GetByID(id);
            if (oldReg == null)
                return "Region does not exist";
            Region? region = DataCreator.GetRegion(name, status, description);
            if (region == null)
                return "Data is invalid";
            if (await _regionDAO.Update(region, id))
                return "Update region sucessfully";
            return "Cannot update this region";
        }

        public async Task<string> RemoveRegion(int id)
        {
            Region? region = await _regionDAO.GetByID(id);
            if (region == null)
                return "Region does not exist";
            if (region.Status == true)
            {
                region.Status = false;
                if (await _regionDAO.Update(region, id))
                    return "This region status is setted to InActive. Click Remove again to actually delete it from database";
            }
            else
            {
                if (await _regionDAO.Remove(id))
                    return "Remove region successfully";
            }
            return "Cannot remove this region";
        }

    }
}