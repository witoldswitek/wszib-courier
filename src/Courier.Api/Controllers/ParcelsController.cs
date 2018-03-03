using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Courier.Core.Commands;

namespace Courier.Api.Controllers
{
    public class ParcelsController : ApiControllerBase
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok();
        }

        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            return Ok();            
        }
        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateParcel command)
        {
            return Ok();
        }
    }
}