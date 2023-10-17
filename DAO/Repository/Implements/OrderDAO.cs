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

        public async Task<Order?> AddnReturn(Order order)
        {
            try
            {
                await _context.Orders.AddAsync(order);
                await _context.SaveChangesAsync();
                return order;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _context.Remove(order);
                await _context.SaveChangesAsync();
                return null;
            }
        }

        public async Task<double> GetTotal(int id)
        {
            double total = new double();
            List<TableOrderDetails> toDetails = await _context.TableOrderDetails.Where(to => to.OrderID == id).ToListAsync();
            await Task.WhenAll(toDetails.Select(async (t) =>
            {
                using (var context = new RMDbContext())
                {
                    List<ProductOrderDetails> poDetails = await context.ProductOrderDetails.Where(po => po.TableOrDtID == t.ID).ToListAsync();
                    poDetails.ForEach((p) =>
                    {
                        total += p.Price * p.Quantity;
                    });
                }
            }));
            return total;
        }

        public async Task<bool> Add(Order order)
        {
            try
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _context.Remove(order);
                await _context.SaveChangesAsync();
                return false;
            }
        }

        public async Task<bool> Update(Order order, int id)
        {
            Order? oldOrd = await _context.Orders.FirstOrDefaultAsync(o => o.ID == id);
            if (oldOrd == null)
                return false;
            try
            {
                oldOrd.CustomerID = order.CustomerID;
                oldOrd.EmployeeID = order.EmployeeID;
                oldOrd.OrderTime = order.OrderTime;
                oldOrd.Status = order.Status;
                oldOrd.Description = order.Description;
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