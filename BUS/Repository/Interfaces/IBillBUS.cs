namespace BUS.Repository.Interfaces
{
    public interface IBillBUS
    {
        public Task<string> AddBill(int? orderID, string? customerName, double? total, string? description, DateTime? billTime);

        public Task<string> UpdateBill(int? orderID, string? customerName, double? total, string? description, DateTime? dateTime, int id);

        public Task<string> RemoveBill(int id);
        
    }
}