using System;
using ComputersInventory.Controllers.BaseControllers;
using ComputersInventory.DAL;
using ComputersInventory.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ComputersInventory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComputerTypesController : BaseCrudApiController<ComputerType>
    {

        private readonly ILogger<ComputerTypesController> ilogger;
        private IComputerTypeRepository iComputerTypeRepository;
        public ComputerTypesController(IComputerTypeRepository computerTypeRepository, ILogger<ComputerTypesController> logger) : base(computerTypeRepository)
        {
            DataRepository = computerTypeRepository;
            iComputerTypeRepository = computerTypeRepository;
            ilogger = logger;
        }

        [HttpGet]
        [Route("GetById")]
        public ActionResult<ComputerType> GetById(int id)
        {
            try
            {
                return iComputerTypeRepository.GetById(id);
            }
            catch (Exception ex)
            {
                ilogger.LogError("Exception in GetById", ex);
                throw;
            }
            
        }
    }
}
