using ComputersInventory.DAL.Interfaces;
using ComputersInventory.DAL.Repositories.BaseRepositories;

namespace ComputersInventory.DAL.Repositories
{
    public class FormFactorRepository : BaseEntityCrudRepository<FormFactor>, IFormFactorRepository
    {
        public FormFactorRepository(ComputerInventoryContext dbContext) : base(
          dbContext)
        {
        }
    }
}
