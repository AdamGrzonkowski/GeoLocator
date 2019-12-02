using GeoLocator.Domain.Entities;
using GeoLocator.Domain.Services.Interfaces.Base;

using System.Threading.Tasks;

namespace GeoLocator.Domain.Services.Interfaces
{
    /// <summary>
    /// Repository for GetLocation.
    /// </summary>
    public interface IGeoLocationRepository : IBaseRepository<GeoLocation>
    {
        /// <summary>
        /// Returns GeoLocation by IP address.
        /// </summary>
        /// <param name="ip">IP address.</param>
        Task<GeoLocation> GetByIpAsync(string ip);
    }
}
