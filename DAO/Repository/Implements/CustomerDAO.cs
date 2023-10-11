using DAO.Repository.Interfaces;
using DAO.Context;
using DTO;
using Microsoft.EntityFrameworkCore;

namespace DAO.Repository.Implements
{
    public class CustomerDAO : DbContextAccessor, ICustomerDAO
    {

        #region Constructors

        public CustomerDAO(RMDbContext context) : base(context)
        {
        }

        #endregion

        
        #region Methods

        public async Task<List<Customer>> GetAll() => await _context.Customers.ToListAsync();

        public async Task<Customer?> GetByID(int id) => await _context.Customers.FirstOrDefaultAsync(r => r.ID == id); 

        public async Task<string> Add(Customer customer)
        {
            try
            {
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return "Added successfully";
            }
            catch (Exception ex)
            {
                _context.Remove(customer);
                await _context.SaveChangesAsync();
                return ex.Message;
            }
        }

        public async Task<string> Update(Customer customer, int id)
        {
            Customer? oldCus = await _context.Customers.FirstOrDefaultAsync(r => r.ID == id);
            if (oldCus == null)
                return "Customer does not exist";
            try
            {
                oldCus.Name = customer.Name;
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
            Customer? customer = await _context.Customers.FirstOrDefaultAsync(c => c.ID == id);
            if (customer == null)
                return "Customer does not exist";
            try
            {
                _context.Remove(customer);
                await _context.SaveChangesAsync();
                return "Remove successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<List<Customer>> GetByName(string name) => await _context.Customers.Where(c => c.Name != null && c.Name.Contains(name)).ToListAsync();

        #endregion

    }
}