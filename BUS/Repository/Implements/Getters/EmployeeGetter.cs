using BUS.Repository.Interfaces.Getters;
using DAO.Repository.Interfaces;
using DTO;

namespace BUS.Repository.Implements.Getters
{
    public class EmployeeGetter : IEmployeeGetter
    {
        IEmployeeDAO _employeeDAO { get; set; }
        public EmployeeGetter(IEmployeeDAO employeeDAO)
        {
            _employeeDAO = employeeDAO;
        }
        public async Task<List<Employee>> GetEmployees()
        {
            return await _employeeDAO.GetAll();
        }
    }
}