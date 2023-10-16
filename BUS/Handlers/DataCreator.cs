using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;
using Azure.Core;
using BUS.Handlers;
using DTO;

namespace BUS.Handler
{
    public class DataCreator
    {
        public static Account? GetAccount(string? username, string? password)
        {
            if (!username.CheckString(50))
                return null;
            if (!password.CheckString(50))
                return null;
            return new Account()
            {
                Username = username,
                Password = password
            };
        }

        public static Region? GetRegion(string? name, bool status, string? description)
        {
            // Checks data here
            if (!name.CheckString(50))
                return null;
            return new Region()
            {
                Name = name,
                Status = status,
                Description = description
            };
        }

        public static Category? GetCategory(string? name, bool status, string? description)
        {
            // Checks data here
            if (!name.CheckString(50))
                return null;
            return new Category()
            {
                Name = name,
                Status = status,
                Description = description
            };
        }

        public static Table? GetTable(string? name, bool status, string? description, int? regionID)
        {
            if (!name.CheckString(50))
                return null;
            return new Table()
            {
                Name = name,
                Status = status,
                Description = description,
                RegionID = regionID
            };
        }

        public static Customer? GetCustomer(string? name)
        {
            if (!name.CheckString(50))
                return null;
            return new Customer()
            {
                Name = name
            };
        }

        public static Employee? GetEmployee(string? name, string? role, string? gender, string? email, bool status, DateTime? birthday)
        {
            if (!name.CheckString(50))
                return null;
            if (!email.CheckEmail())
                return null;
            if (birthday == null)
                return null;
            return new Employee()
            {
                Name = name,
                Role = role,
                Gender = gender,
                Email = email,
                Status = status,
                BirthDay = (DateTime)birthday
            };
        }

        public static Product? GetProduct(string? name, double unitPrice, bool status, string? image, string? description)
        {
            if (!name.CheckString(50))
                return null;
            if (unitPrice == 0)
                return null;
            return new Product()
            {
                Name = name,
                UnitPrice = unitPrice,
                Status = status,
                Image = image,
                Description = description
            };
        }

        public static Bill? GetBill(int? orderID, string? customerName, double? total, string? description, DateTime? billTime = null)
        {
            return new Bill()
            {
                OrderID = orderID,
                CustomerName = customerName,
                Total = total?? 0,
                Description = description,
                BillTime = billTime?? DateTime.Now
            };
        }

        public static Order? GetOrder(DateTime orderTime, int? employeeID = null, int? customerID = null, bool status = false, string? description = null)
        {
            return new Order()
            {
                OrderTime = orderTime,
                Status = status,
                Description = description,
                EmployeeID = employeeID,
                CustomerID = customerID
            };
        }

        public static TableOrderDetails? GetTODetails(int orderID, int? tableID, bool status = false, string? description = null)
        {
            return new TableOrderDetails()
            {
                OrderID = orderID,
                TableID = tableID,
                Status = status,
                Description = description
            };
        }

        public static ProductOrderDetails? GetPODetails(int tableOrDtID, int? productID, double price, int quantity, string? description = null)
        {
            return new ProductOrderDetails()
            {
                TableOrDtID = tableOrDtID,
                ProductID = productID,
                Price = price,
                Quantity = quantity,
                Description = description
            };
        }
    }
}