using DAO.Repository.Interfaces;
using DAO.Context;
using DTO;
using Microsoft.EntityFrameworkCore;

namespace DAO.Repository.Implements
{
    public class TableDAO : DbContextAccessor, ITableDAO
    {

        #region Constructors

        public TableDAO(RMDbContext context) : base(context)
        {
        }

        #endregion

        
        #region Methods

        public async Task<List<Table>> GetAll() => await _context.Tables.ToListAsync();

        public async Task<Table?> GetByID(int id) => await _context.Tables.FirstOrDefaultAsync(r => r.ID == id); 

        public async Task<bool> Add(Table table)
        {
            try
            {
                _context.Add(table);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _context.Remove(table);
                await _context.SaveChangesAsync();
                return false;
            }
        }

        public async Task<bool> Update(Table table, int id)
        {
            Table? oldTab = await _context.Tables.FirstOrDefaultAsync(t => t.ID == id);
            if (oldTab == null)
                return false;
            try
            {
                oldTab.Name = table.Name;
                oldTab.Description = table.Description;
                oldTab.Status = table.Status;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<bool> Remove(int id)
        {
            Table? table = await _context.Tables.FirstOrDefaultAsync(t => t.ID == id);
            if (table == null)
                return false;
            try
            {
                _context.Remove(table);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<List<Table>> GetByName(string name) => await _context.Tables.Where(t => t.Name != null && t.Name.Contains(name)).ToListAsync();

        #endregion

    }
}