using DAO.Repository.Interfaces;
using DAO.Context;
using DTO;
using Microsoft.EntityFrameworkCore;

namespace DAO.Repository.Implements
{
    public class CategoryDAO : DbContextAccessor, ICategoryDAO
    {

        #region Constructors

        public CategoryDAO(RMDbContext context) : base(context)
        {
        }

        #endregion

        
        #region Methods

        public async Task<List<Category>> GetAll() => await _context.Categories.ToListAsync();

        public async Task<Category?> GetByID(int id) => await _context.Categories.FirstOrDefaultAsync(c => c.ID == id); 

        public async Task<string> Add(Category category)
        {
            try
            {
                _context.Add(category);
                await _context.SaveChangesAsync();
                return "Added successfully";
            }
            catch (Exception ex)
            {
                _context.Remove(category);
                await _context.SaveChangesAsync();
                return ex.Message;
            }
        }

        public async Task<string> Update(Category category, int id)
        {
            Category? oldCate = await _context.Categories.FirstOrDefaultAsync(c => c.ID == id);
            if (oldCate == null)
                return "Category does not exist";
            try
            {
                oldCate.Name = category.Name;
                oldCate.Description = category.Description;
                oldCate.Status = category.Status;
                await _context.SaveChangesAsync();
                return "Update successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> Remove(int id)
        {
            Category? category = await _context.Categories.FirstOrDefaultAsync(c => c.ID == id);
            if (category == null)
                return "Category does not exist";
            try
            {
                _context.Remove(category);
                await _context.SaveChangesAsync();
                return "Remove successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<List<Category>> GetByName(string name) => await _context.Categories.Where(c => c.Name != null && c.Name.Contains(name)).ToListAsync();

        #endregion

    }

}
