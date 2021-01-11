using ComputersInventory.Controllers.BaseControllers;
using ComputersInventory.DAL;
using ComputersInventory.DAL.Interfaces;
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
 
    }
}
