using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Courier.Core.Commands;
using Courier.Core.Services;

namespace Courier.Api.Controllers
{
    public class ParcelsController : ApiControllerBase
    {
        
        private readonly IParcelService _parcelService;

        public ParcelsController(IParcelService parcelService,ILocationService locationService)
        {
        
            _parcelService = parcelService;
        }

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

        [HttpGet("delivery-available/{address}")]
        public async Task<IActionResult> DeliveryAvailable(string address)
        {
            var deliveryAvailable = await _parcelService.DeliveryAvailableAsync(address);
            if(deliveryAvailable)
            {
                return Ok();
            }
            return BadRequest();
        }



        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateParcel command)
        {
            await _parcelService.CreateAsync(command.Id, command.Name, command.SenderId, command.ReceiverId, command.ReceiverAddress);
            return CreatedAtAction(nameof(Get), new { id = command.Id }, null);
        }

    }
}