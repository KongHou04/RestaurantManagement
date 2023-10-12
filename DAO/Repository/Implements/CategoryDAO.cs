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

        public async Task<bool> Add(Category category)
        {
            try
            {
                _context.Add(category);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _context.Remove(category);
                await _context.SaveChangesAsync();
                return false;
            }
        }

        public async Task<bool> Update(Category category, int id)
        {
            Category? oldCate = await _context.Categories.FirstOrDefaultAsync(c => c.ID == id);
            if (oldCate == null)
                return false;
            try
            {
                oldCate.Name = category.Name;
                oldCate.Description = category.Description;
                oldCate.Status = category.Status;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<bool> Remove(int id)
        {
            Category? category = await _context.Categories.FirstOrDefaultAsync(c => c.ID == id);
            if (category == null)
                return false;
            try
            {
                _context.Remove(category);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<List<Category>> GetByName(string name) => await _context.Categories.Where(c => c.Name != null && c.Name.Contains(name)).ToListAsync();

        #endregion

    }

}
