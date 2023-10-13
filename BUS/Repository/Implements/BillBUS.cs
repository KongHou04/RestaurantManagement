using System.Reflection.Metadata.Ecma335;
using System.Net.Http.Headers;
using BUS.Handler;
using BUS.Repository.Interfaces;
using DAO.Repository.Interfaces;
using DTO;

namespace BUS.Repository.Implements
{
    public class BillBUS : IBillBUS
    {
        IBillDAO _billDAO;
        IOrderDAO _orderDAO;
        ICustomerDAO _customerDAO;
        ITODetailsDAO _toDetailsDAO;
        IPODetailsDAO _poDetailsDAO;

        public BillBUS(IBillDAO billDAO, IOrderDAO orderDAO, ICustomerDAO customerDAO, ITODetailsDAO toDetailsDAO, IPODetailsDAO poDetailsDAO)
        {
            _billDAO = billDAO;
            _orderDAO = orderDAO;
            _customerDAO = customerDAO;
            _toDetailsDAO = toDetailsDAO;
            _poDetailsDAO = poDetailsDAO;
        }

        public async Task<string> AddBill(int? orderID, string? customerName, double? total, string? description, DateTime? dateTime = null)
        {
            if (orderID != null)
            {
                Order? order = await _orderDAO.GetByID((int)orderID);
                if (order != null)
                {
                    if (order.CustomerID != null)
                    {
                        Customer? customer = await _customerDAO.GetByID((int)order.CustomerID);
                        if (customer != null)
                            customerName = customer.Name;
                    }
                    List<TableOrderDetails> toDetails = await _toDetailsDAO.GetEntitysByFK(order);
                    toDetails.ForEach(async (ot) => {
                        List<ProductOrderDetails> poDetails = await _poDetailsDAO.GetEntitysByFK(ot);
                        poDetails.ForEach((po) =>{
                            total += po.Price * po.Quantity;
                        });
                    });
                }
            }
            Bill? bill = DataCreator.GetBill(orderID, customerName, total, description, dateTime);
            if (bill == null)
                return "Cannot create bill for this order";
            if (await _billDAO.Add(bill))
                return "Create bill successfully";
            return "Cannot create bill for this order";
        }

        public async Task<string> UpdateBill(int? orderID, string? customerName, double? total, string? description, DateTime? dateTime, int id)
        {
            Bill? oldBill = await _billDAO.GetByID(id);
            if (oldBill == null)
                return "Bill does not exist";
            Bill? bill = DataCreator.GetBill(orderID, customerName, total, description, dateTime);
            if (bill == null)
                return "Data is invalid";
            if (oldBill.Total != bill.Total)
                if (oldBill.Description == bill.Description)
                    return "If you want to change total, You need to note reason for that";
            if (await _billDAO.Update(bill, id))
                return "Update bill sucessfully";
            return "Cannot update this bill";
        }

        public async Task<string> RemoveBill(int id)
        {
            // Bill? bill = await _billDAO.GetByID(id);
            // if (bill == null)
            //     return "Bill does not exist";
            // if (bill.Status == true)
            // {
            //     category.Status = false;
            //     if (await _categoryDAO.Update(category, id))
            //         return "This category status is setted to InActive. Click Remove again to actually delete it from database";
            // }
            // else
            // {
            //     if (await _categoryDAO.Remove(id))
            //         return "Remove category successfully";
            // }
            // return "Cannot remove this category";
            return await Task.FromResult("Dont allow to remove any bill");
            // Update Table Bill - add status to update this method
            // Before that, you dont allow to remove any Bill from database
        }
        
    }
}