using ComputersInventory.DAL.Interfaces;
using ComputersInventory.DAL.Repositories.BaseRepositories;
using System;
using System.Collections.Generic;
using System.Text;

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
