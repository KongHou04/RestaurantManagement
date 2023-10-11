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

        public async Task<string> Add(ProductOrderDetails poDetails)
        {
            try
            {
                _context.Add(poDetails);
                await _context.SaveChangesAsync();
                return "Added successfully";
            }
            catch (Exception ex)
            {
                _context.Remove(poDetails);
                await _context.SaveChangesAsync();
                return ex.Message;
            }
        }

        public async Task<string> Update(ProductOrderDetails poDetails, int id)
        {
            ProductOrderDetails? oldPOD = await _context.ProductOrderDetails.FirstOrDefaultAsync(po => po.ID == id);
            if (oldPOD == null)
                return "POD does not exist";
            try
            {
                oldPOD.ProductID = poDetails.ProductID;
                oldPOD.Price = poDetails.Price;
                oldPOD.Quantity = poDetails.Quantity;
                oldPOD.Description = poDetails.Description;
                oldPOD.TableOrDtID = poDetails.TableOrDtID;
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
            ProductOrderDetails? poDetails = await _context.ProductOrderDetails.FirstOrDefaultAsync(po => po.ID == id);
            if (poDetails == null)
                return "POD does not exist";
            try
            {
                _context.Remove(poDetails);
                await _context.SaveChangesAsync();
                return "Remove successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        #endregion

    }
}