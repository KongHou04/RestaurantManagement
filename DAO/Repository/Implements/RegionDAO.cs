using DAO.Repository.Interfaces;
using DAO.Context;
using DTO;
using Microsoft.EntityFrameworkCore;

namespace DAO.Repository.Implements
{
    public class RegionDAO : DbContextAccessor, IRegionDAO
    {

        #region Constructors

        public RegionDAO(RMDbContext context) : base(context)
        {
        }

        #endregion

        
        #region Methods

        public async Task<List<Region>> GetAll() => await _context.Regions.ToListAsync();

        public async Task<Region?> GetByID(int id) => await _context.Regions.FirstOrDefaultAsync(r => r.ID == id); 

        public async Task<bool> Add(Region region)
        {
            try
            {
                _context.Add(region);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _context.Remove(region);
                await _context.SaveChangesAsync();
                return false;
            }
        }

        public async Task<bool> Update(Region region, int id)
        {
            Region? oldReg = await _context.Regions.FirstOrDefaultAsync(r => r.ID == id);
            if (oldReg == null)
                return false;
            try
            {
                oldReg.Name = region.Name;
                oldReg.Description = region.Description;
                oldReg.Status = region.Status;
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
            Region? region = await _context.Regions.FirstOrDefaultAsync(r => r.ID == id);
            if (region == null)
                return false;
            try
            {
                _context.Remove(region);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<List<Region>> GetByName(string name) => await _context.Regions.Where(r => r.Name != null && r.Name.Contains(name)).ToListAsync();

        #endregion

    }
}