using DTO;

namespace BUS.Repository.Interfaces.Getters
{
    public interface IRegionGetter
    {
        public Task<List<Region>> GetRegions();
    }
}