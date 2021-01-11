using ComputersInventory.DAL.DomainModels;
using ComputersInventory.DAL.Extensions;
using ComputersInventory.DAL.Interfaces;
using ComputersInventory.DAL.Repositories.BaseRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputersInventory.DAL.Repositories
{
    public class ComputerRepository : BaseEntityCrudRepository<Computer>, IComputerRepository
    {
        private List<string> columnNames = new List<string>();
        public ComputerRepository(ComputerInventoryContext dbContext) : base(
       dbContext)
        {
        }


        //public List<ComputerTypeCheckboxValue> ColumnsList(bool newItem = true)
        //{
        //    try
        //    {

        //        var columns = typeof(Computer).GetProperties()
        //                .Select(property => property.Name)
        //                .ToList();
        //        columns.Remove("ComputerId");
        //        columns.Remove("ComputerTypeId");
        //        columns.Remove("ComputerType");
        //        columns.Remove("FormFactorNavigation");
        //        columns.Remove("ScreenSize");
        //        var checkboxList = new List<ComputerTypeCheckboxValue>();

        //        foreach (var column in columns)
        //        {
        //            checkboxList.Add(new ComputerTypeCheckboxValue()
        //            {
        //                UniqueName = column,
        //                Name = string.Concat(column.Replace("Id", "")
        //                .Select(c => Char.IsUpper(c) ? " " + c : c.ToString())).TrimStart(),
        //                Checked = false
        //            });
        //        }
        //        return checkboxList;
        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }
        //}

        //public ResultSetDTO ComputerList(string orderBy = null, string orderDirection = null, int pageNumber = -1,
        //    int sizeOfPage = -1, string filterParams = null)
        //{
        //    var query = (from c in dbContext.Computers
        //                 join ct in dbContext.ComputerTypes on c.ComputerTypeId equals ct.ComputerTypeId
        //                 join ss in dbContext.ScreenSizes on c.ScreenSizeId equals ss.ScreenSizeId
        //                 join ff in dbContext.FormFactors on c.FormFactor equals ff.FormFactorId
        //                 select new
        //                 {
        //                     c.ComputerId,
        //                     c.ComputerTypeId,
        //                     c.Brand,
        //                     c.Processor,
        //                     c.RamSlots,
        //                     c.Quantity,
        //                     c.UsbPorts,
        //                     c.ScreenSizeId,
        //                     c.FormFactor,
        //                     c.IsActive
        //                 }).QueryGenerator(orderBy, orderDirection, pageNumber, sizeOfPage, filterParams);
        //    return new ResultSetDTO
        //    {
        //        totalRecords = query.Count(),
        //        records = query
        //            .ApplyPagination(pageNumber, sizeOfPage).ToList()
        //    };
        //}
    }
}
