namespace BUS.Repository.Interfaces
{
    public interface ICategoryBUS
    {
        public Task<string> AddCategory(string? name, bool status, string? description);

        public Task<string> UpdateCategory(string? name, bool status, string? description, int id);

        public Task<string> RemoveCategory(int id);
        
    }
}