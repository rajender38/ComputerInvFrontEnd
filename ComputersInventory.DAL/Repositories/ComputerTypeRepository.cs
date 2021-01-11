using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComputersInventory.DAL.DomainModels;
using ComputersInventory.DAL.Extensions;
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
