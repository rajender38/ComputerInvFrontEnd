using System.Linq;
using ComputersInventory.DAL.Interfaces;
using ComputersInventory.DAL.Repositories.BaseRepositories;

namespace ComputersInventory.DAL.Repositories
{
    public class ComputerTypeRepository: BaseEntityCrudRepository<ComputerType>, IComputerTypeRepository
    {
        public ComputerTypeRepository(ComputerInventoryContext dbContext) : base(
          dbContext)
        {
        }

        public ComputerType GetById(int value)
        {
            return dbContext.ComputerTypes.Where(s => s.ComputerTypeId == value).FirstOrDefault();

        }
    }
}
