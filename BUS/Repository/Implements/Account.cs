using BUS.Repository.Interfaces;
using DAO.Repository.Interfaces;
using DTO;

namespace BUS.Repository.Implements
{
    public class AccountBUS : IAccountBUS
    {
        private IAccountDAO _accountDAO;

        public AccountBUS(IAccountDAO accountDAO)
        {
            _accountDAO = accountDAO;
        }

        public async Task<Account?> Login(string username, string password, bool isRemember)
        {
            Account? account = await _accountDAO.GetByID(username);
            if (account == null)
                return null;
            if (account.Password != password)
                return null;
            return account;
        }

        public Task<string> SendResetPassCode(string email)
        {
            // Send Mail
            return new Task<string>(() => {return "";});
        }

        public async Task<string> SetNewPassword(string username, string password)
        {
            return await _accountDAO.Update(new Account(){Password = password}, username);
        }

    }
}