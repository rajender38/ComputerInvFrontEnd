using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComputersInventory.DAL.DomainModels;
using ComputersInventory.DAL.Extensions;

namespace ComputersInventory.DAL.Repositories.BaseRepositories
{
    public class BaseEntityRepository<T> where T : class
    {
        public readonly ComputerInventoryContext dbContext;
        public BaseEntityRepository(ComputerInventoryContext context)
        {
            dbContext = context;
        }

        public virtual ResultSetDTO Retrieve(string orderBy = null, string orderDirection = null, int pageNumber = -1,
            int sizeOfPage = -1, string filterParams = null)
        {


            var query = dbContext.Set<T>()
                .QueryGenerator(orderBy, orderDirection, pageNumber, sizeOfPage, filterParams);

            return new ResultSetDTO
            {
                totalRecords = query.Count(),
                records = query
                    .ApplyPagination(pageNumber, sizeOfPage).ToList()
            };
        }
    }
}
