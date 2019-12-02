namespace GeoLocator.Application.Dtos
{
    /// <summary>
    /// Dto for sending request to GeoLocation endpoint.
    /// </summary>
    public class GeoLocationRequestDto
    {
        /// <summary>
        /// IP by which to find GeoLocation.
        /// </summary>
        public string Ip { get; set; }

        /// <summary>
        /// Hostname by which to find GeoLocation. Must be provided with protocol, so for example http://www.google.com
        /// </summary>
        public string Hostname { get; set; }
    }
}
