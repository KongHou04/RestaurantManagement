using BUS.Repository.Interfaces.Getters;
using DAO.Repository.Interfaces;
using DTO;

namespace BUS.Repository.Implements.Getters
{
    public class CategoryGetter : ICategoryGetter
    {
        ICategoryDAO _categoryDAO { get; set; }
        public CategoryGetter(ICategoryDAO categoryDAO)
        {
            _categoryDAO = categoryDAO;
        }
        public async Task<List<Category>> GetCategories()
        {
            return await _categoryDAO.GetAll();
        }
    }
}