namespace BUS.Repository.Interfaces.Setters
{
    public interface IOrderBUS
    {
        public Task<string> AddOrder(int? orderID, int tableID, int productID, int? employeeID, int? customerID);

        public Task<string> IncreaseProductOrder(int poDetailsID, int num);

        public Task<string> DecreaseProductOrder(int poDetailsID, int num);

    }
}