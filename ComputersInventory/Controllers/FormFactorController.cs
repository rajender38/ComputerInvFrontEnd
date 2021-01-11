using ComputersInventory.Controllers.BaseControllers;
using ComputersInventory.DAL;
using ComputersInventory.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ComputersInventory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormFactorController :  BaseCrudApiController<FormFactor>
    {
        public FormFactorController(IFormFactorRepository formFactorRepository) : base(formFactorRepository)
        {
            DataRepository = formFactorRepository;
        }
    }
}
