using DTO;

namespace BUS.Repository.Interfaces
{
    public interface IAccountBUS
    {
        public Task<Account?> Login(string username, string password, bool isRemember);

        public Task<string> SendResetPassCode(string email);

        public Task<string> SetNewPassword(string username, string password);

    }
}