using DAO.Repository.Interfaces;
using DAO.Context;
using DTO;
using Microsoft.EntityFrameworkCore;

namespace DAO.Repository.Implements
{
    public class TODetailsDAO : DbContextAccessor, ITODetailsDAO 
    {

        #region Constructors

        public TODetailsDAO(RMDbContext context) : base(context)
        {
        }

        #endregion

        
        #region Methods

        public async Task<List<TableOrderDetails>> GetAll() => await _context.TableOrderDetails.ToListAsync();

        public async Task<TableOrderDetails?> GetByID(int id) => await _context.TableOrderDetails.FirstOrDefaultAsync(to => to.ID == id); 

        public async Task<string> Add(TableOrderDetails toDetails)
        {
            try
            {
                _context.Add(toDetails);
                await _context.SaveChangesAsync();
                return "Added successfully";
            }
            catch (Exception ex)
            {
                _context.Remove(toDetails);
                await _context.SaveChangesAsync();
                return ex.Message;
            }
        }

        public async Task<string> Update(TableOrderDetails toDetails, int id)
        {
            TableOrderDetails? oldTOD = await _context.TableOrderDetails.FirstOrDefaultAsync(to => to.ID == id);
            if (oldTOD == null)
                return "Order does not exist";
            try
            {
                
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
            Order? order = await _context.Orders.FirstOrDefaultAsync(o => o.ID == id);
            if (order == null)
                return "Order does not exist";
            try
            {
                _context.Remove(order);
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