using ComputersInventory.DAL.Interfaces;
using ComputersInventory.DAL.Repositories.BaseRepositories;

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
