using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComputersInventory.DAL.DomainModels;

namespace ComputersInventory.DAL.Interfaces
{
    public interface IBaseEntityCrudRepository<T> where T : class
    {
        Task<int> Create(T record);
        Task<T> Update(T record);
        Task<int> Delete(T record);

        ResultSetDTO Retrieve(string orderBy = null, string orderDirection = null, int pageNumber = -1,
            int sizeOfPage = -1, string filterParams = null);

        Task<T> GetSingleAsync(int identifier);


    }
}
