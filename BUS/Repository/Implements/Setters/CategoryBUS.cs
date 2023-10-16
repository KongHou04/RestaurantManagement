using BUS.Handler;
using BUS.Repository.Interfaces.Setters;
using DAO.Repository.Interfaces;
using DTO;

namespace BUS.Repository.Implements.Setters
{
    public class CategoryBUS : ICategoryBUS
    {
        ICategoryDAO _categoryDAO;

        public CategoryBUS(ICategoryDAO categoryDAO)
        {
            _categoryDAO = categoryDAO;
        }

        public async Task<string> AddCategory(string? name, bool status, string? description)
        {
            Category? category = DataCreator.GetCategory(name, status, description);
            if (category == null)
                return "Data is invalid";
            if (await _categoryDAO.Add(category))
                return "Add new category successfully";
            return "Cannot add new category";
        }

        public async Task<string> UpdateCategory(string? name, bool status, string? description, int id)
        {
            Category? oldCat = await _categoryDAO.GetByID(id);
            if (oldCat == null)
                return "Category does not exist";
            Category? category = DataCreator.GetCategory(name, status, description);
            if (category == null)
                return "Data is invalid";
            if (await _categoryDAO.Update(category, id))
                return "Update category sucessfully";
            return "Cannot update this category";
        }

        public async Task<string> RemoveCategory(int id)
        {
            Category? category = await _categoryDAO.GetByID(id);
            if (category == null)
                return "Category does not exist";
            if (category.Status == true)
            {
                category.Status = false;
                if (await _categoryDAO.Update(category, id))
                    return "This category status is setted to InActive. Click Remove again to actually delete it from database";
            }
            else
            {
                if (await _categoryDAO.Remove(id))
                    return "Remove category successfully";
            }
            return "Cannot remove this category";
        }

    }
}