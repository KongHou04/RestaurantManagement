using BUS.Handler;
using BUS.Repository.Interfaces;
using DAO.Repository.Interfaces;
using DTO;

namespace BUS.Repository.Implements
{
    public class TableBUS : ITableBUS
    {
        ITableDAO _tableDAO;

        public TableBUS(ITableDAO tableDAO)
        {
            _tableDAO = tableDAO;
        }

        public async Task<string> AddTable(string? name, bool status, string? description, int? regionID)
        {
            Table? table = DataCreator.GetTable(name, status, description, regionID);
            if (table == null)
                return "Data is invalid";
            if (await _tableDAO.Add(table))
                return "Add new table successfully";
            return "Cannot add new table";
        }

        public async Task<string> UpdateTable(string? name, bool status, string? description, int? regionID, int id)
        {
            Table? oldTab = await _tableDAO.GetByID(id);
            if (oldTab == null)
                return "Table does not exist";
            Table? table = DataCreator.GetTable(name, status, description, regionID);
            if (table == null)
                return "Data is invalid";
            if (await _tableDAO.Update(table, id))
                return "Update table sucessfully";
            return "Cannot update this table";
        }
        
        public async Task<string> RemoveTable(int id)
        {
            Table? table = await _tableDAO.GetByID(id);
            if (table == null)
                return "Table does not exist";
            if (table.Status == true)
            {
                table.Status = false;
                if (await _tableDAO.Update(table, id))
                    return "This table status is setted to InActive. Click Remove again to actually delete it from database";
            }
            else
            {
                if (await _tableDAO.Remove(id))
                    return "Remove table successfully";
            }
            return "Cannot remove this table";
        }
        
    }
}