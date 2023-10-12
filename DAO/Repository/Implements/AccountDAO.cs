using DAO.Repository.Interfaces;
using DAO.Context;
using DTO;
using Microsoft.EntityFrameworkCore;

namespace DAO.Repository.Implements
{
    public class AccountDAO :  DbContextAccessor, IAccountDAO
    {

        #region Constructors

        public AccountDAO(RMDbContext context) : base(context)
        {
        }

        #endregion

        
        #region Methods

        public async Task<List<Account>> GetAll() => await _context.Accounts.ToListAsync();

        public async Task<Account?> GetByID(string username) => await _context.Accounts.FirstOrDefaultAsync(a => a.Username == username); 

        public async Task<bool> Add(Account account)
        {
            try
            {
                _context.Add(account);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _context.Remove(account);
                await _context.SaveChangesAsync();
                return false;
            }
        }

        public async Task<bool> Update(Account account, string username)
        {
            Account? oldAcc = await _context.Accounts.FirstOrDefaultAsync(a => a.Username == username);
            if (oldAcc == null)
                return false;
            try
            {
                oldAcc.Username = account.Username;
                oldAcc.Password = account.Password;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<bool> Remove(string username)
        {
            Account? oldAcc = await _context.Accounts.FirstOrDefaultAsync(a => a.Username == username);
            if (oldAcc == null)
                return false;
            try
            {
                _context.Remove(oldAcc);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<List<Account>> GetByName(string username) => await _context.Accounts.Where(a => a.Username != null && a.Username.Contains(username)).ToListAsync();

        #endregion

    }
}