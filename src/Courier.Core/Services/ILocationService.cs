using Courier.Core.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Courier.Core.Services
{
    public interface ILocationService
    {
        Task<bool> ExistAsync(string address);
        Task<AddressDto> GetAsync(string address);
        
    }
}
