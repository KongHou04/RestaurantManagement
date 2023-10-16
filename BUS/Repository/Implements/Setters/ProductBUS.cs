using BUS.Handler;
using BUS.Repository.Interfaces;
using BUS.Repository.Interfaces.Setters;
using DAO.Repository.Interfaces;
using DTO;

namespace BUS.Repository.Implements.Setters
{
    public class ProductBUS : IProductBUS
    {
        IProductDAO _productDAO;

        public ProductBUS(IProductDAO productDAO)
        {
            _productDAO = productDAO;
        }

        public async Task<string> AddProduct(string? name, double unitPrice, bool status, string? image, string? description)
        {
            Product? product = DataCreator.GetProduct(name, unitPrice, status, image, description);
            if (product == null)
                return "Data is invalid";
            if (await _productDAO.Add(product))
                return "Add new product successfully";
            return "Cannot add new product";
        }

        public async Task<string> UpdateProduct(string? name, double unitPrice, bool status, string? image, string? description, int id)
        {
            Product? oldPro = await _productDAO.GetByID(id);
            if (oldPro == null)
                return "Product does not exist";
            Product? product = DataCreator.GetProduct(name, unitPrice, status, image, description);
            if (product == null)
                return "Data is invalid";
            if (await _productDAO.Update(product, id))
                return "Update prodcut sucessfully";
            return "Cannot update this product";
        }

        public async Task<string> RemoveProduct(int id)
        {
            Product? product = await _productDAO.GetByID(id);
            if (product == null)
                return "Product does not exist";
            if (product.Status == true)
            {
                product.Status = false;
                if (await _productDAO.Update(product, id))
                    return "This product status is setted to InActive. Click Remove again to actually delete it from database";
            }
            else
            {
                if (await _productDAO.Remove(id))
                    return "Remove product successfully";
            }
            return "Cannot remove this product";
        }

    }
}