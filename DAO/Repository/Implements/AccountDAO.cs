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

        public async Task<string> Add(Account account)
        {
            try
            {
                _context.Add(account);
                await _context.SaveChangesAsync();
                return "Added successfully";
            }
            catch (Exception ex)
            {
                _context.Remove(account);
                await _context.SaveChangesAsync();
                return ex.Message;
            }
        }

        public async Task<string> Update(Account account, string username)
        {
            Account? oldAcc = await _context.Accounts.FirstOrDefaultAsync(a => a.Username == username);
            Account? sameAccUsername = await _context.Accounts.FirstOrDefaultAsync(a => a.Username == account.Username);
            if (oldAcc == null)
                return "Account does not exist";
            if (sameAccUsername != null)
                return "Username already exists";
            try
            {
                oldAcc.Username = account.Username;
                oldAcc.Password = account.Password;
                await _context.SaveChangesAsync();
                return "Update successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> Remove(string username)
        {
            Account? oldAcc = await _context.Accounts.FirstOrDefaultAsync(a => a.Username == username);
            if (oldAcc == null)
                return "Account does not exist";
            try
            {
                _context.Remove(oldAcc);
                await _context.SaveChangesAsync();
                return "Remove successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<List<Account>> GetByName(string username) => await _context.Accounts.Where(a => a.Username != null && a.Username.Contains(username)).ToListAsync();

        #endregion

    }
}