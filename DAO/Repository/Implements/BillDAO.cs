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

        public async Task<string> Add(Bill bill)
        {
            try
            {
                _context.Add(bill);
                await _context.SaveChangesAsync();
                return "Added successfully";
            }
            catch (Exception ex)
            {
                _context.Remove(bill);
                await _context.SaveChangesAsync();
                return ex.Message;
            }
        }

        public async Task<string> Update(Bill bill, int id)
        {
            Bill? oldBill = await _context.Bills.FirstOrDefaultAsync(a => a.ID == id);
            if (oldBill == null)
                return "Bill does not exist";
            try
            {
                oldBill.BillTime = bill.BillTime;
                oldBill.CustomerName = bill.CustomerName;
                oldBill.Description = bill.Description;
                oldBill.Total = bill.Total;
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
            Bill? bill = await _context.Bills.FirstOrDefaultAsync(b => b.ID == id);
            if (bill == null)
                return "Bill does not exist";
            try
            {
                _context.Remove(bill);
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