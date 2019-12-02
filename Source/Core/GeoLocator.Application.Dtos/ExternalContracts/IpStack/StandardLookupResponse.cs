using System.Collections.Generic;

namespace GeoLocator.Application.Dtos.ExternalContracts.IpStack
{
    /// <summary>
    /// Response returned from IpStack external API on Standard Lookup action.
    /// </summary>
    public class StandardLookupResponse
    {
        /// <summary>
        /// Returns the requested IP address.
        /// </summary>
        public string ip { get; set; }

        /// <summary>
        /// Returns the IP address type IPv4 or IPv6.
        /// </summary>
        public string type { get; set; }

        /// <summary>
        /// Returns the 2-letter continent code associated with the IP.
        /// </summary>
        public string continent_code { get; set; }

        /// <summary>
        /// Returns the name of the continent associated with the IP.
        /// </summary>
        public string continent_name { get; set; }

        /// <summary>
        /// Returns the 2-letter country code associated with the IP.
        /// </summary>
        public string country_code { get; set; }

        /// <summary>
        /// Returns the name of the country associated with the IP.
        /// </summary>
        public string country_name { get; set; }

        /// <summary>
        /// Returns the region code of the region associated with the IP (e.g. CA for California).
        /// </summary>
        public string region_code { get; set; }

        /// <summary>
        /// Returns the name of the region associated with the IP.
        /// </summary>
        public string region_name { get; set; }

        /// <summary>
        /// Returns the name of the city associated with the IP.
        /// </summary>
        public string city { get; set; }

        /// <summary>
        /// Returns the ZIP code associated with the IP.
        /// </summary>
        public string zip { get; set; }

        /// <summary>
        /// Returns the latitude value associated with the IP.
        /// </summary>
        public double latitude { get; set; }

        /// <summary>
        /// Returns the longitude value associated with the IP.
        /// </summary>
        public double longitude { get; set; }

        /// <summary>
        /// [Object] Returns multiple location-related objects
        /// </summary>
        public Location location { get; set; }
    }

    public class Location
    {
        /// <summary>
        /// Returns the unique geoname identifier in accordance with the Geonames Registry.
        /// </summary>
        public int geoname_id { get; set; }

        /// <summary>
        /// Returns the capital city of the country associated with the IP.
        /// </summary>
        public string capital { get; set; }

        /// <summary>
        /// Returns an HTTP URL leading to an SVG-flag icon for the country associated with the IP.
        /// </summary>
        public string country_flag { get; set; }

        /// <summary>
        /// Returns the emoji icon for the flag of the country associated with the IP.
        /// </summary>
        public string country_flag_emoji { get; set; }

        /// <summary>
        /// Returns the unicode value of the emoji icon for the flag of the country associated with the IP. 
        /// (e.g. U+1F1F5 U+1F1F9 for the Portuguese flag)
        /// </summary>
        public string country_flag_emoji_unicode { get; set; }

        /// <summary>
        /// Returns the calling/dial code of the country associated with the IP. (e.g. 351) for Portugal.
        /// </summary>
        public string calling_code { get; set; }

        /// <summary>
        /// Returns true or false depending on whether or not the county associated with the IP is in the European Union.
        /// </summary>
        public bool is_eu { get; set; }

        /// <summary>
        /// [Object] Returns an object containing one or multiple sub-objects per language spoken 
        /// in the country associated with the IP.
        /// </summary>
        public IEnumerable<Language> languages { get; set; }
    }

    public class Language
    {
        /// <summary>
        /// Returns the 2-letter language code for the given language.
        /// </summary>
        public string code { get; set; }

        /// <summary>
        /// Returns the name (in the API request's main language) of the given language. (e.g. Portuguese)
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Returns the native name of the given language. (e.g. Português)
        /// </summary>
        public string native { get; set; }
    }
}