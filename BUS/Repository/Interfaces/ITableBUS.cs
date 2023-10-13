using DTO;

namespace BUS.Repository.Interfaces
{
    public interface ITableBUS
    {
        public Task<string> AddTable(string? name, bool status, string? description, int? regionID);

        public Task<string> UpdateTable(string? name, bool status, string? description, int? regionID, int id);

        public Task<string> RemoveTable(int id);
        
    }
}