using ComputersInventory.Controllers.BaseControllers;
using ComputersInventory.DAL;
using ComputersInventory.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ComputersInventory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScreenSizeController : BaseCrudApiController<ScreenSize>
    {
        public ScreenSizeController(IScreenSizeRepository screenSizeRepository) : base(screenSizeRepository)
        {
            DataRepository = screenSizeRepository;
        }
    }
}
