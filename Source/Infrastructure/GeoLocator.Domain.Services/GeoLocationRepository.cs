using GeoLocator.Domain.Entities;
using GeoLocator.Domain.Services.Base;
using GeoLocator.Domain.Services.Interfaces;

using System.Threading.Tasks;

namespace GeoLocator.Domain.Services
{
    /// <inheritdoc />
    public class GeoLocationRepository : BaseRepository<GeoLocation>, IGeoLocationRepository
    {
        public GeoLocationRepository(IDbContext context) : base(context)
        {
        }

        /// <inheritdoc />
        public async Task<GeoLocation> GetByIpAsync(string ip)
        {
            return await GetAsync(x => x.Ip == ip)
                .ConfigureAwait(false);
        }
    }
}
