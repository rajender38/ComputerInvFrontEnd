using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputersInventory.DAL.Extensions
{
    public static class Paginator
    {
        public static IQueryable<object> ApplyPagination(this IQueryable<object> dataSet, int pageNumber = -1,
            int sizeOfPage = -1)
        {
            if (sizeOfPage <= 0) return dataSet;

            if (pageNumber >= 0)
            {
                int skipValue = sizeOfPage * pageNumber;
                dataSet = dataSet.OrderBy(x => true).Skip(skipValue).Take(sizeOfPage);
            }

            return dataSet;
        }
    }
}
