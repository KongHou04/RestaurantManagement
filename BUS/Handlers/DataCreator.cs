using Azure.Core;
using DTO;

namespace BUS.Handler
{
    public class DataCreator
    {
        public static Region? GetRegion(string? name, bool status, string? description)
        {
            // Checks data here
            if (name == null)
                return null;
            return new Region()
            {
                Name = name,
                Status = status,
                Description = description
            };
        }
    }
}