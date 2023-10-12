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

        public async Task<bool> Add(Employee employee)
        {
            try
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _context.Remove(employee);
                await _context.SaveChangesAsync();
                return false;
            }
        }

        public async Task<bool> Update(Employee employee, int id)
        {
            Employee? oldEmp = await _context.Employees.FirstOrDefaultAsync(e => e.ID == id);
            if (oldEmp == null)
                return false;
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
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return  false;
            }
        }

        public async Task<bool> Remove(int id)
        {
            Employee? employee = await _context.Employees.FirstOrDefaultAsync(e => e.ID == id);
            if (employee == null)
                return false;
            try
            {
                _context.Remove(employee);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<List<Employee>> GetByName(string name) => await _context.Employees.Where(e => e.Name != null && e.Name.Contains(name)).ToListAsync();

        #endregion

    }
}