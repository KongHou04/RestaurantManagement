using BUS.Handler;
using BUS.Repository.Interfaces;
using DAO.Repository.Interfaces;
using DTO;

namespace BUS.Repository.Implements
{
    public class EmployeeBUS : IEmployeeBUS
    {
        IEmployeeDAO _employeeDAO;
        IAccountDAO _accountDAO;

        public EmployeeBUS(IEmployeeDAO employeeDAO, IAccountDAO accountDAO)
        {
            _employeeDAO = employeeDAO;
            _accountDAO = accountDAO;
        }

        public async Task<string> AddEmployee(string? name, string? role, string? gender, string? email, bool status, DateTime? birthday, string username, string password)
        {
            Employee? employee = DataCreator.GetEmployee(name, role, gender, email, status, birthday);
            Account? account = DataCreator.GetAccount(username, password);
            if (employee == null)
                return "Data is invalid";
            if (account == null)
                return "Username or password is invalid";
            if (_accountDAO.GetByID("username") != null)
                return "Username is same to other account name";
            account.Password = account.Password?.EncodeString();
            if (await _accountDAO.Add(account)){
                employee.Username = username;
                if (await _employeeDAO.Add(employee))
                    return "Add new employee successfully";
                await _accountDAO.Remove(username);
            }
            return "Cannot add new employee";
        }

        public async Task<string> UpdateEmployee(string? name, string? role, string? gender, string? email, bool status, DateTime? birthday, int id)
        {
            Employee? oldEmp = await _employeeDAO.GetByID(id);
            if (oldEmp == null)
                return "Employee does not exist";
            Employee? employee = DataCreator.GetEmployee(name, role, gender, email, status, birthday);
            if (employee == null)
                return "Data is invalid";
            if (await _employeeDAO.Update(employee, id))
                return "Update employee sucessfully";
            return "Cannot update this employee";
        }

        public async Task<string> RemoveEmployee(int id)
        {
            Employee? employee = await _employeeDAO.GetByID(id);
            if (employee == null)
                return "Employee does not exist";
            if (employee.Status == true)
            {
                employee.Status = false;
                if (await _employeeDAO.Update(employee, id))
                    return "This employee status is setted to InActive. Click Remove again to actually delete it from database";
            }
            else
            {
                if (await _employeeDAO.Remove(id))
                    return "Remove employee successfully";
            }
            return "Cannot remove this employee";
        }

    }
}