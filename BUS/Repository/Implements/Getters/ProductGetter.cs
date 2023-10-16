using BUS.Repository.Interfaces.Getters;
using DAO.Repository.Implements;
using DAO.Repository.Interfaces;
using DTO;

namespace BUS.Repository.Implements.Getters
{
    public class ProductGetter : IProductGetter
    {
        IProductDAO _producDAO { get; set; }
        public ProductGetter(IProductDAO productDAO)
        {
            _producDAO = productDAO;
        }
        public async Task<List<Product>> GetProducts()
        {
            return await _producDAO.GetAll();
        }
    }
}


