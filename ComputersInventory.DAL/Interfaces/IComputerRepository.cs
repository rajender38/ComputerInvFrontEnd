using ComputersInventory.DAL.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputersInventory.DAL.Interfaces
{
    public interface IComputerRepository : IBaseEntityCrudRepository<Computer>
    {

        //public List<ComputerTypeCheckboxValue> ColumnsList(bool newItem = true);
        //public ResultSetDTO ComputerList(string orderBy = null, string orderDirection = null, int pageNumber = -1,
        //    int sizeOfPage = -1, string filterParams = null);
    }
}
