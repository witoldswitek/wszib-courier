using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Courier.Api.Controllers
{
    [Route("")]
    public class HomeController : ApiControllerBase
    {
        public IActionResult Get()
            => Content("Welcome to Courier API.");
        
    }
}