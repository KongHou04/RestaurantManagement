using DAO.Repository.Interfaces;
using DAO.Context;
using DTO;
using Microsoft.EntityFrameworkCore;

namespace DAO.Repository.Implements
{
    public class OrderDAO : DbContextAccessor, IOrderDAO
    {

        #region Constructors

        public OrderDAO(RMDbContext context) : base(context)
        {
        }

        #endregion

        
        #region Methods

        public async Task<List<Order>> GetAll() => await _context.Orders.ToListAsync();

        public async Task<Order?> GetByID(int id) => await _context.Orders.FirstOrDefaultAsync(o => o.ID == id); 

        public async Task<string> Add(Order order)
        {
            try
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                return "Added successfully";
            }
            catch (Exception ex)
            {
                _context.Remove(order);
                await _context.SaveChangesAsync();
                return ex.Message;
            }
        }

        public async Task<string> Update(Order order, int id)
        {
            Order? oldOrd = await _context.Orders.FirstOrDefaultAsync(o => o.ID == id);
            if (oldOrd == null)
                return "Order does not exist";
            try
            {
                oldOrd.CustomerID = order.CustomerID;
                oldOrd.EmployeeID = order.EmployeeID;
                oldOrd.OrderTime = order.OrderTime;
                oldOrd.Status = order.Status;
                oldOrd.Description = order.Description;
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