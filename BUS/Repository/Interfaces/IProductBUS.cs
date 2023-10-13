namespace BUS.Repository.Interfaces
{
    public interface IProductBUS
    {
        public Task<string> AddProduct(string? name, double unitPrice, bool status, string? image, string? description);

        public Task<string> UpdateProduct(string? name, double unitPrice, bool status, string? image, string? description, int id);

        public Task<string> RemoveProduct(int id);
    }
}