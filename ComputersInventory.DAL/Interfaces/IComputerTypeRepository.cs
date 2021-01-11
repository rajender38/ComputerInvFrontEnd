using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComputersInventory.DAL;

namespace ComputersInventory.DAL.Interfaces
{
    public interface IComputerTypeRepository : IBaseEntityCrudRepository<ComputerType>
    {
        public ComputerType GetById(int value);
    }
}
