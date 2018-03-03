﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Courier.Core.Dto;
using System.Net.Http;
using Newtonsoft.Json;
using System.Linq;

namespace Courier.Core.Services
{
    public class LocationService : ILocationService
    {
        private static readonly Uri _apiUrl = new Uri("https://maps.googleapis.com/maps/api/geocode/json");
        private static readonly HttpClient _client = new HttpClient
        {
            BaseAddress = _apiUrl
        };

        public async Task<bool> ExistAsync(string address)
            => await GetAsync(address) != null;
        

        public async Task<AddressDto> GetAsync(string address)
        {
            var response = await _client.GetAsync($"?address={address}&key=AIzaSyD5UaNtOrvxjvxUJscB1qsCfHrPWv6UTtk");
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            var content =  await response.Content.ReadAsStringAsync();
            var location = JsonConvert.DeserializeObject<LocationResponse>(content);
            if (location==null || !location.Results.Any())
            {
                return null;
            }
            var result = location.Results.FirstOrDefault();


            return result == null ? null : new AddressDto
            {
                Latitude = result.Geometry.Location.Lat,
                Longitude = result.Geometry.Location.Lng,
                Location = result.FormattedAddress
            };
        }
       private class LocationResponse
        {
            public IEnumerable<LocationResults> Results { get; set; }
        }
        private class LocationResults
        {
            [JsonProperty(PropertyName = "formatted_address")]
            public string FormattedAddress { get; set; }
            [JsonProperty(PropertyName = "address_components")]
            public IEnumerable<AddressComponent> AddressComponents { get; set; }
            public Geometry Geometry { get; set; }
        }
        private class AddressComponent
        {
            [JsonProperty(PropertyName = "long_name")]
            public string LongName { get; set; }
            [JsonProperty(PropertyName = "short_name")]
            public string ShortName { get; set; }
            [JsonProperty(PropertyName = "types")]
            public IEnumerable<string> Types { get; set; }
        }

        private class Geometry
        {
            public GeometryLocation Location { get; set; }
        }
        private class GeometryLocation
        {
            public double Lat { get; set; }
            public double Lng { get; set; }
        }
    }
}
