using ComputersInventory.DAL.Interfaces;
using ComputersInventory.DAL.Repositories.BaseRepositories;
using System.Collections.Generic;


namespace ComputersInventory.DAL.Repositories
{
    public class ComputerRepository : BaseEntityCrudRepository<Computer>, IComputerRepository
    {
        private List<string> columnNames = new List<string>();
        public ComputerRepository(ComputerInventoryContext dbContext) : base(
       dbContext)
        {
        }
    }
}
