using DAO.Repository.Interfaces;
using DAO.Context;
using DTO;
using Microsoft.EntityFrameworkCore;

namespace DAO.Repository.Implements
{
    public class BillDAO : DbContextAccessor, IBillDAO
    {

        #region Constructors

        public BillDAO(RMDbContext context) : base(context)
        {
        }

        #endregion

        
        #region Methods

        public async Task<List<Bill>> GetAll() => await _context.Bills.ToListAsync();

        public async Task<Bill?> GetByID(int id) => await _context.Bills.FirstOrDefaultAsync(b => b.ID == id); 

        public async Task<bool> Add(Bill bill)
        {
            try
            {
                _context.Add(bill);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _context.Remove(bill);
                await _context.SaveChangesAsync();
                return false;
            }
        }

        public async Task<bool> Update(Bill bill, int id)
        {
            Bill? oldBill = await _context.Bills.FirstOrDefaultAsync(a => a.ID == id);
            if (oldBill == null)
                return false;
            try
            {
                oldBill.BillTime = bill.BillTime;
                oldBill.CustomerName = bill.CustomerName;
                oldBill.Description = bill.Description;
                oldBill.Total = bill.Total;
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
            Bill? bill = await _context.Bills.FirstOrDefaultAsync(b => b.ID == id);
            if (bill == null)
                return false;
            try
            {
                _context.Remove(bill);
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