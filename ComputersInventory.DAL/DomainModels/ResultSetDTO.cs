using System.Collections.Generic;

namespace ComputersInventory.DAL.DomainModels
{
    public class ResultSetDTO
    {
        public int totalRecords { get; set; } = 0;
        public IEnumerable<object> records { get; set; }
    }
}
