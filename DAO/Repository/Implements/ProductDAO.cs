using System.Diagnostics;
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
        public async Task<double> GetUnitPrice(int id)
        {
            Product? product = await _context.Products.FirstOrDefaultAsync(p => p.ID == id);
            if (product != null)
                return product.UnitPrice;
            return -1;
        } 

        public async Task<bool> Add(Product product)
        {
            try
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _context.Remove(product);
                await _context.SaveChangesAsync();
                return false;
            }
        }

        public async Task<bool> Update(Product product, int id)
        {
            Product? oldPro = await _context.Products.FirstOrDefaultAsync(p => p.ID == id);
            if (oldPro == null)
                return false;
            try
            {
                oldPro.Name = product.Name;
                oldPro.UnitPrice = product.UnitPrice;
                oldPro.Status = product.Status;
                oldPro.Image = product.Image;
                oldPro.Description = product.Description;
                oldPro.CategoryID = product.CategoryID;
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
            Product? product = await _context.Products.FirstOrDefaultAsync(p => p.ID == id);
            if (product == null)
                return false;
            try
            {
                _context.Remove(product);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<List<Product>> GetByName(string name) => await _context.Products.Where(p => p.Name != null && p.Name.Contains(name)).ToListAsync();

        #endregion

    }
}