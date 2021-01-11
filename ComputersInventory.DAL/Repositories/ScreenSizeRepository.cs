using ComputersInventory.DAL.Interfaces;
using ComputersInventory.DAL.Repositories.BaseRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputersInventory.DAL.Repositories
{
    public class ScreenSizeRepository : BaseEntityCrudRepository<ScreenSize>, IScreenSizeRepository
    {
        public ScreenSizeRepository(ComputerInventoryContext dbContext) : base(
          dbContext)
        {
        }
    }

}
