using DAO.Repository.Interfaces;
using DAO.Context;
using DTO;
using Microsoft.EntityFrameworkCore;

namespace DAO.Repository.Implements
{
    public class ProductDAO : DbContextAccessor, IProductDAO
    {

        #region Constructors

        public ProductDAO(RMDbContext context) : base(context)
        {
        }

        #endregion

        
        #region Methods

        public async Task<List<Product>> GetAll() => await _context.Products.ToListAsync();

        public async Task<Product?> GetByID(int id) => await _context.Products.FirstOrDefaultAsync(p => p.ID == id); 

        public async Task<string> Add(Product product)
        {
            try
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return "Added successfully";
            }
            catch (Exception ex)
            {
                _context.Remove(product);
                await _context.SaveChangesAsync();
                return ex.Message;
            }
        }

        public async Task<string> Update(Product product, int id)
        {
            Product? oldPro = await _context.Products.FirstOrDefaultAsync(p => p.ID == id);
            if (oldPro == null)
                return "Product does not exist";
            try
            {
                oldPro.Name = product.Name;
                oldPro.UnitPrice = product.UnitPrice;
                oldPro.Status = product.Status;
                oldPro.Image = product.Image;
                oldPro.Description = product.Description;
                oldPro.CategoryID = product.CategoryID;
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
            Product? product = await _context.Products.FirstOrDefaultAsync(p => p.ID == id);
            if (product == null)
                return "Product does not exist";
            try
            {
                _context.Remove(product);
                await _context.SaveChangesAsync();
                return "Remove successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<List<Product>> GetByName(string name) => await _context.Products.Where(p => p.Name != null && p.Name.Contains(name)).ToListAsync();

        #endregion

    }
}