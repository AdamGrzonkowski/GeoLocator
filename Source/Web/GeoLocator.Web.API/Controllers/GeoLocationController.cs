using GeoLocator.Application.Dtos;
using GeoLocator.Application.Services.Interfaces;
using GeoLocator.Shared.Helper;

using log4net;

using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace GeoLocator.Web.API.Controllers
{
    [RoutePrefix("api/geolocation")]
    public class GeoLocationController : ApiController
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(GeoLocationController));
        private readonly IGeoLocationService _service;
        public GeoLocationController(IGeoLocationService service)
        {
            _service = service;
        }

        /// <summary>
        /// This endpoint receives an IP address or URL and based on that retrieves GeoLocation data from the database.
        /// </summary>
        /// <param name="dto">Request object.</param>
        /// <remarks>
        /// Asynchronously saves record to database.
        /// </remarks>
        /// <response code="200">Object was successfully retrieved.</response>
        /// <response code="400">No IP or Hostname were provided in request body or they were badly formatted.</response>
        /// <response code="404">GeoLocation does not exist for such IP / hostname.</response>
        [HttpGet]
        public async Task<IHttpActionResult> GetLocationAsync([FromUri] GeoLocationRequestDto dto)
        {
            try
            {
                if (ValidationHelper.ValidateIp(dto.Ip))
                {
                    var responseDto = await _service.GetAsync(dto.Ip)
                        .ConfigureAwait(false);

                    return Ok(responseDto);
                }
                else if (ValidationHelper.ValidateUrl(dto.Hostname))
                {
                    var result = await GetIpFromHostname(dto.Hostname)
                        .ConfigureAwait(false);

                    if (result.Success)
                    {
                        var responseDto = await _service.GetAsync(result.Message)
                            .ConfigureAwait(false);

                        return Ok(responseDto);
                    }
                    else
                    {
                        return Content(HttpStatusCode.NotFound, "GeoLocation does not exist for such IP / hostname.");
                    }
                }
                else
                {
                    return BadRequest("No IP or Hostname were provided in request body or they were badly formatted.");
                }
            }
            catch (Exception ex)
            {
                HandleException(ex); ;
            }

            return Ok();
        }

        /// <summary>
        /// This endpoint receives an IP address or URL and based on that finds GeoLocation and stores it in database.
        /// </summary>
        /// <param name="requests">Requests in chosen format.</param>
        /// <remarks>
        /// Asynchronously saves record to database.
        /// </remarks>
        /// <response code="200">Object was created successfully.</response>
        /// <response code="400">No IP nor Hostname were provided in request body.</response>
        /// <response code="404">GeoLocation does not exist for such IP / hostname.</response>
        /// <response code="503">External system for getting GeoLocation is not available at the moment.</response>
        [HttpPost]
        [ResponseType(typeof(string))]
        public async Task<IHttpActionResult> PostAsync([FromBody] GeoLocationRequestDto dto)
        {
            try
            {
                if (ValidationHelper.ValidateIp(dto.Ip))
                {
                    var responseDto = await _service.GetAsync(dto.Ip)
                        .ConfigureAwait(false);

                    return Ok(responseDto);
                }
                else if (ValidationHelper.ValidateUrl(dto.Hostname))
                {
                    var result = await GetIpFromHostname(dto.Hostname)
                        .ConfigureAwait(false);

                    if (result.Success)
                    {
                        var responseDto = await _service.GetAsync(result.Message)
                            .ConfigureAwait(false);

                        return Ok(responseDto);
                    }
                    else
                    {
                        return Content(HttpStatusCode.NotFound, "GeoLocation does not exist for such IP / hostname.");
                    }
                }
                else
                {
                    return BadRequest("No IP or Hostname were provided in request body or they were badly formatted.");
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return Ok();
        }

        /// <summary>
        /// This endpoint receives an IP address or URL and based on that deletes stored GeoLocation from database. 
        /// </summary>
        /// <param name="requests">Requests in chosen format.</param>
        /// <remarks>
        /// Asynchronously deletes record from the database.
        /// </remarks>
        /// <response code="204">Record has been successfully deleted.</response>
        /// <response code="404">Record was not found.</response>
        [HttpDelete]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> DeleteAsync([FromUri] Guid id)
        {
            try
            {

            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        private void HandleException(Exception ex)
        {
            _logger.Error(ex);
            HttpResponseMessage response = this.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Sorry, something went wrong. Our hamsters are already on it.");
            throw new HttpResponseException(response);
        }

        private async Task<ResultObject> GetIpFromHostname(string hostname)
        {
            var dnsSafeHost = (new Uri(hostname)).DnsSafeHost;
            var ipHostEntry = await Dns.GetHostEntryAsync(dnsSafeHost);

            var result = new ResultObject();

            if (ipHostEntry.AddressList.Length > 0)
            {
                result.Success = true;
                result.Message = ipHostEntry.AddressList[0].ToString();
            }
            else
            {
                result.Message = "GeoLocation does not exist for such IP / hostname.";
            }

            return result;
        }
    }
}
