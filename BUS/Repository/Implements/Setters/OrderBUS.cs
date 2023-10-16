using BUS.Handler;
using BUS.Repository.Interfaces.Setters;
using DAO.Repository.Implements;
using DAO.Repository.Interfaces;
using DTO;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace BUS.Repository.Implements.Setters
{
    public class OrderBUS : IOrderBUS
    {
        IOrderDAO _orderDAO;
        ITODetailsDAO _toDetailsDAO;
        IPODetailsDAO _poDetailsDAO;
        IProductDAO _productDAO;

        public OrderBUS(IOrderDAO orderDAO, ITODetailsDAO toDetailsDAO, IPODetailsDAO poDetailsDAO, IProductDAO productDAO)
        {
            _orderDAO = orderDAO;
            _toDetailsDAO = toDetailsDAO;
            _poDetailsDAO = poDetailsDAO;
            _productDAO = productDAO;
        }

        public async Task<string> AddOrder(int? orderID, int tableID, int productID, int? employeeID = null, int? customerID = null)
        {
            Order? order;
            TableOrderDetails? toDetails;
            ProductOrderDetails? poDetails;
            if (orderID == null)
            {
                order = DataCreator.GetOrder(DateTime.Now, employeeID, customerID);
                if (order != null)
                order = await _orderDAO.AddnReturn(order);
            }
            else
                order = await _orderDAO.GetByID((int)orderID);
            if (order == null)
                return "Cannot create order";

            toDetails = await _toDetailsDAO.GetEntityBy2FK(order, new Table(){ID = tableID});
            if (toDetails == null)
            {
                toDetails = DataCreator.GetTODetails(order.ID, tableID);
                if (toDetails == null)
                    return "Cannot create order";
                toDetails = await _toDetailsDAO.AddnReturn(toDetails);
            }
            if (toDetails == null)
                return "Cannot create order";
            double price = await _productDAO.GetUnitPrice(productID);
            poDetails = DataCreator.GetPODetails(toDetails.ID, productID, price, 1);
            if (poDetails != null)
            if (await _poDetailsDAO.Add(poDetails))
                return "Add successfully";
            return "Cannot add new order";
        }
        
        public async Task<string> IncreaseProductOrder(int poDetailsID, int num = 1)
        {
            ProductOrderDetails? poDetails = await _poDetailsDAO.GetByID(poDetailsID);
            if (poDetails == null)
                return "Order does not exist";
            poDetails.Quantity = poDetails.Quantity + num;
            if (await _poDetailsDAO.Update(poDetails, poDetails.ID))
                return "Update sucessfully";
            return "Cannot update order";
        }

        public async Task<string> DecreaseProductOrder(int poDetailsID, int num = 1)
        {
            ProductOrderDetails? poDetails = await _poDetailsDAO.GetByID(poDetailsID);
            if (poDetails == null)
                return "Order does not exist";
            poDetails.Quantity = poDetails.Quantity - num;
            if (poDetails.Quantity <= 0)
            {
                if (await _poDetailsDAO.Remove(poDetails.ID))
                    return "Remove order successfully";
                return "Cannot remove order";
            }
            if (await _poDetailsDAO.Update(poDetails, poDetails.ID))
                return "Update sucessfully";
            return "Cannot update order";
        }

        public async Task<string> RemoveOrder(int orderID)
        {
            List<TableOrderDetails> toDetails = await _toDetailsDAO.GetEntitysByFK(new Order(){ID = orderID});
            toDetails.ForEach(async (to) => {
                List<ProductOrderDetails> poDetails = await _poDetailsDAO.GetEntitysByFK(to);
                poDetails.ForEach(async (po) => {
                    await _poDetailsDAO.Remove(po.ID);
                });
                await _toDetailsDAO.Remove(to.ID);
            });
            if (await _orderDAO.Remove(orderID))
                return "Remove order successfully";
            return "Cannot remove order";
        }
    }
}