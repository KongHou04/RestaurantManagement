using DTO;

namespace BUS.Repository.Interfaces.Getters
{
    public interface IProductGetter
    {
        public Task<List<Product>> GetProducts();
    }
}


