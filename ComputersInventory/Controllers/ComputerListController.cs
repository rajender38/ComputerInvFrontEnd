using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComputersInventory.Controllers.BaseControllers;
using ComputersInventory.DAL;
using ComputersInventory.DAL.DomainModels;
using ComputersInventory.DAL.Interfaces;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComputersInventory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComputerListController : BaseCrudApiController<Computer>
    {
        private IComputerRepository iComputerRepository;
        public ComputerListController(IComputerRepository computerRepository) 
            : base(computerRepository)
        {
            DataRepository = computerRepository;
            this.iComputerRepository = computerRepository;
        }

        //[HttpGet]
        //[Route("GetColumnList")]
        //public ActionResult<List<ComputerTypeCheckboxValue>> GetColumnList()
        //{
        //    return iComputerRepository.ColumnsList();
        //}
        //[HttpGet]
        //[Route("GetComputerList")]
        //public ActionResult<ResultSetDTO> GetComputerList(string orderBy = null, string orderDirection = null, int pageNumber = -1,
        //    int sizeOfPage = -1, string filterParams = null)
        //{
        //    return iComputerRepository.ComputerList(orderBy, orderDirection, pageNumber,
        //     sizeOfPage ,  filterParams );
        //}
    }
}
