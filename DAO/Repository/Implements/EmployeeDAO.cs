using DAO.Repository.Interfaces;
using DAO.Context;
using DTO;
using Microsoft.EntityFrameworkCore;

namespace DAO.Repository.Implements
{
    public class EmployeeDAO : DbContextAccessor, IEmployeeDAO
    {

        #region Constructors

        public EmployeeDAO(RMDbContext context) : base(context)
        {
        }

        #endregion

        
        #region Methods

        public async Task<List<Employee>> GetAll() => await _context.Employees.ToListAsync();

        public async Task<Employee?> GetByID(int id) => await _context.Employees.FirstOrDefaultAsync(e => e.ID == id); 

        public async Task<string> Add(Employee employee)
        {
            try
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return "Added successfully";
            }
            catch (Exception ex)
            {
                _context.Remove(employee);
                await _context.SaveChangesAsync();
                return ex.Message;
            }
        }

        public async Task<string> Update(Employee employee, int id)
        {
            Employee? oldEmp = await _context.Employees.FirstOrDefaultAsync(e => e.ID == id);
            if (oldEmp == null)
                return "Employee does not exist";
            try
            {
                oldEmp.Name = employee.Name;
                oldEmp.Role = employee.Role;
                oldEmp.BirthDay = employee.BirthDay;
                oldEmp.Gender = employee.Gender;
                oldEmp.Email = employee.Email;
                oldEmp.Status = employee.Status;
                oldEmp.Avatar = employee.Avatar;
                await _context.SaveChangesAsync();
                return "Update successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> Remove(int id)
        {
            Employee? employee = await _context.Employees.FirstOrDefaultAsync(e => e.ID == id);
            if (employee == null)
                return "Employee does not exist";
            try
            {
                _context.Remove(employee);
                await _context.SaveChangesAsync();
                return "Remove successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<List<Employee>> GetByName(string name) => await _context.Employees.Where(e => e.Name != null && e.Name.Contains(name)).ToListAsync();

        #endregion

    }
}