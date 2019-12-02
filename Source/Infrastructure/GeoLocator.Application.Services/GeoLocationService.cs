using GeoLocator.Application.Dtos;
using GeoLocator.Application.Dtos.ExternalContracts.IpStack;
using GeoLocator.Application.Services.Interfaces;
using GeoLocator.Domain.Entities;
using GeoLocator.Domain.Services.Interfaces;

using Newtonsoft.Json;

using System;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;

namespace GeoLocator.Application.Services
{
    public class GeoLocationService : IGeoLocationService
    {
        private readonly HttpClient _client = new HttpClient();
        private readonly IGeoLocationRepository _repo;
        public GeoLocationService(IGeoLocationRepository repo)
        {
            _repo = repo;
        }

        public async Task<Guid> AddAsync(string ip)
        {
            var geoLocationFromIpStack = await GetGeoLocationFromIpStack(ip)
                .ConfigureAwait(false);

            // some mapping logic here
            throw new NotImplementedException();
            GeoLocation entity = null;

            _repo.InsertAsync(entity)
                .ConfigureAwait(false);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<GeoLocationResponseDto> GetAsync(string ip)
        {
            // try to retrieve from db first. If not exists, then from ipStack

            var geoLocationFromIpStack = await GetGeoLocationFromIpStack(ip)
                .ConfigureAwait(false);

            // some mapping logic here
            // entity.Ip = geoLocationFromIpStack.Ip; bla bla bla
            // var id = await _repo.InsertAsync(entity).ConfigureAwait(false);
            throw new NotImplementedException();
        }

        private async Task<StandardLookupResponse> GetGeoLocationFromIpStack(string ip)
        {
            var ipStackAccessKey = ConfigurationManager.AppSettings["ipStack:apiAccessKey"];
            var ipStackBaseUrl = ConfigurationManager.AppSettings["ipStack:apiBaseAddress"];

            string url = $"{ipStackBaseUrl}/{ip}?access_key={ipStackAccessKey}";

            HttpResponseMessage response = await _client.GetAsync(url)
                .ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            string jsonString = await response.Content.ReadAsStringAsync()
                .ConfigureAwait(false);

            return JsonConvert.DeserializeObject<StandardLookupResponse>(jsonString);
        }
    }
}
