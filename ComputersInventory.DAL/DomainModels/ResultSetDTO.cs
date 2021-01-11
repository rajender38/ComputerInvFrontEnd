using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputersInventory.DAL.DomainModels
{
    public class ResultSetDTO
    {
        public int totalRecords { get; set; } = 0;
        public IEnumerable<object> records { get; set; }
    }
}
