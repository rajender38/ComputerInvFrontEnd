using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComputersInventory.Controllers.BaseControllers;
using ComputersInventory.DAL;
using ComputersInventory.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace ComputersInventory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComputerTypesController : BaseCrudApiController<ComputerType>
    {

        private IComputerTypeRepository iComputerTypeRepository;
        public ComputerTypesController(IComputerTypeRepository computerTypeRepository) : base(computerTypeRepository)
        {
            DataRepository = computerTypeRepository;
            iComputerTypeRepository = computerTypeRepository;
        }

        [HttpGet]
        [Route("GetById")]
        public ActionResult<ComputerType> GetById(int id)
        {
            return iComputerTypeRepository.GetById(id);
        }
    }
}
