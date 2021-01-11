using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ComputersInventory.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FirstController : ControllerBase
    {


        private readonly ILogger<FirstController> _logger;

        public FirstController(ILogger<FirstController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            return "Web API";
        }
    }
}
