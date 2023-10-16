using DTO;

namespace BUS.Repository.Interfaces.Getters
{
    public interface IEmployeeGetter
    {
        public Task<List<Employee>> GetEmployees();
    }
}