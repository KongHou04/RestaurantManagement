using BUS.Handler;
using BUS.Repository.Interfaces.Setters;
using DAO.Repository.Interfaces;
using DTO;

namespace BUS.Repository.Implements.Setters
{
    public class CustomerBUS : ICustomerBUS
    {
        ICustomerDAO _customerDAO;

        public CustomerBUS(ICustomerDAO customerDAO)
        {
            _customerDAO = customerDAO;
        }

        public async Task<string> AddCustomer(string? name)
        {
            Customer? customer = DataCreator.GetCustomer(name);
            if (customer == null)
                return "Data is invalid";
            if (await _customerDAO.Add(customer))
                return "Add new customer successfully";
            return "Cannot add new customer";
        }

        public async Task<string> UpdateCustomer(string? name, int id)
        {
            Customer? oldCus = await _customerDAO.GetByID(id);
            if (oldCus == null)
                return "Customer does not exist";
            Customer? customer = DataCreator.GetCustomer(name);
            if (customer == null)
                return "Data is invalid";
            if (await _customerDAO.Update(customer, id))
                return "Update customer sucessfully";
            return "Cannot update this customer";
        }

        public async Task<string> RemoveCustomer(int id)
        {
            Customer? customer = await _customerDAO.GetByID(id);
            if (customer == null)
                return "Customer does not exist";
            if (await _customerDAO.Remove(id))
                return "Remove customer successfully";
            return "Cannot remove this customer";
        }

    }
}