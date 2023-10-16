using System.ComponentModel;
using DTO;
namespace BUS.Repository.Interfaces.Setters
{
    public interface IRegionBUS
    {
        public Task<string> AddRegion(string? name, bool status, string? description);

        public Task<string> UpdateRegion(string? name, bool status, string? description, int id);

        public Task<string> RemoveRegion(int id);
        
    }
}