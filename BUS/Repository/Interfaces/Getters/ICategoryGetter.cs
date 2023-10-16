using DTO;

namespace BUS.Repository.Interfaces.Getters
{
    public interface ICategoryGetter
    {
        public Task<List<Category>> GetCategories();
    }
}