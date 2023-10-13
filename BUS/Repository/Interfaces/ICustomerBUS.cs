namespace BUS.Repository.Interfaces
{
    public interface ICustomerBUS
    {
        public Task<string> AddCustomer(string? name);

        public Task<string> UpdateCustomer(string? name, int id);

        public Task<string> RemoveCustomer(int id);
    }
}