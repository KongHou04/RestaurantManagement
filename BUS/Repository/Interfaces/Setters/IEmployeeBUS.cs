namespace BUS.Repository.Interfaces.Setters
{
    public interface IEmployeeBUS
    {
        public Task<string> AddEmployee(string? name, string? role, string? gender, string? email, bool status, DateTime? birthday, string username, string password);

        public Task<string> UpdateEmployee(string? name, string? role, string? gender, string? email, bool status, DateTime? birthday, int id);

        public Task<string> RemoveEmployee(int id);
    }
}