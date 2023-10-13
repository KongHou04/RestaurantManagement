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

        public async Task<List<TableOrderDetails>> GetEntitysByFK(Order order) => await _context.TableOrderDetails.Where(to => to.OrderID == order.ID).ToListAsync();

        public async Task<bool> Add(TableOrderDetails toDetails)
        {
            try
            {
                _context.Add(toDetails);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _context.Remove(toDetails);
                await _context.SaveChangesAsync();
                return false;
            }
        }

        public async Task<bool> Update(TableOrderDetails toDetails, int id)
        {
            TableOrderDetails? oldTOD = await _context.TableOrderDetails.FirstOrDefaultAsync(to => to.ID == id);
            if (oldTOD == null)
                return false;
            try
            {
                
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
            Order? order = await _context.Orders.FirstOrDefaultAsync(o => o.ID == id);
            if (order == null)
                return false;
            try
            {
                _context.Remove(order);
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