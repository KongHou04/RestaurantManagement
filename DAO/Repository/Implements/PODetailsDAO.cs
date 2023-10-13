using DAO.Repository.Interfaces;
using DAO.Context;
using DTO;
using Microsoft.EntityFrameworkCore;

namespace DAO.Repository.Implements
{
    public class PODetailsDAO : DbContextAccessor, IPODetailsDAO
    {

        #region Constructors

        public PODetailsDAO(RMDbContext context) : base(context)
        {
        }

        #endregion

        
        #region Methods

        public async Task<List<ProductOrderDetails>> GetAll() => await _context.ProductOrderDetails.ToListAsync();

        public async Task<ProductOrderDetails?> GetByID(int id) => await _context.ProductOrderDetails.FirstOrDefaultAsync(po => po.ID == id); 

        public async Task<List<ProductOrderDetails>> GetEntitysByFK(TableOrderDetails tableOrderDetails) => await _context.ProductOrderDetails.Where(po => po.TableOrDtID == tableOrderDetails.ID).ToListAsync();

        public async Task<bool> Add(ProductOrderDetails poDetails)
        {
            try
            {
                _context.Add(poDetails);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _context.Remove(poDetails);
                await _context.SaveChangesAsync();
                return false;
            }
        }

        public async Task<bool> Update(ProductOrderDetails poDetails, int id)
        {
            ProductOrderDetails? oldPOD = await _context.ProductOrderDetails.FirstOrDefaultAsync(po => po.ID == id);
            if (oldPOD == null)
                return false;
            try
            {
                oldPOD.ProductID = poDetails.ProductID;
                oldPOD.Price = poDetails.Price;
                oldPOD.Quantity = poDetails.Quantity;
                oldPOD.Description = poDetails.Description;
                oldPOD.TableOrDtID = poDetails.TableOrDtID;
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
            ProductOrderDetails? poDetails = await _context.ProductOrderDetails.FirstOrDefaultAsync(po => po.ID == id);
            if (poDetails == null)
                return false;
            try
            {
                _context.Remove(poDetails);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        #endregion

    }
}