using BUS.Handler;
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
            if (account.Password != password.EncodeString())
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
            Account? account = await _accountDAO.GetByID(username);
            if (account == null)
                return "Account does not exist";
            if (await _accountDAO.Update(new Account(){Password = password.EncodeString()}, username))
                return "Set new password successfully";
            return "Cannot set new password";
        }

    }
}