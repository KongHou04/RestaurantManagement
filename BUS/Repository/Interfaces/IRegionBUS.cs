using System.ComponentModel;
namespace BUS.Repository.Interfaces
{
    public interface IRegionBUS
    {
        public Task<string> AddNewRegion(string name, bool status, string description);

        public Task<string> UpdateRegion(string name, bool status, string description, int id);
        
    }
}