using GeoLocator.Application.Dtos;

using System;
using System.Threading.Tasks;

namespace GeoLocator.Application.Services.Interfaces
{
    public interface IGeoLocationService
    {
        Task<Guid> AddAsync(string ip);
        Task<GeoLocationResponseDto> GetAsync(string ip);
        Task<bool> DeleteAsync(Guid id);
    }
}
