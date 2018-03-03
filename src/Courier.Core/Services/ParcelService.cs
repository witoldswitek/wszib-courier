using Courier.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Courier.Core.Services
{
    class ParcelService : IParcelService
    {
        private static readonly ISet<Parcel> _parcels = new HashSet<Parcel>();
        private readonly ILocationService _locationService;

        public ParcelService(ILocationService locationService)
        {
            _locationService = locationService;
        }

        public async Task CreateAsync(Guid id, string name, Guid senderId, Guid receiverId, string receiverAddress)
        {
            var address = await _locationService.GetAsync(receiverAddress);
            if (address==null)
            {
                throw new ArgumentException($"Invalid receiver address '{address}'.", nameof(receiverAddress));
            }
            var sender = GetUser(senderId);
            var receiver= GetUser(receiverId);
            var parcel = new Parcel(id, name, sender, receiver, null, Address.Create(address.Latitude, address.Longitude, address.Location));
            _parcels.Add(parcel);
        }

        public async Task<bool> DeliveryAvailableAsync(string address)
            => await _locationService.ExistAsync(address);
        

        private User GetUser(Guid id)
            => new User($"{id}@email.com", "first", "last");
        
    }
}
