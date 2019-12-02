using System.Collections.Generic;

namespace GeoLocator.Domain.Entities
{

    public class GeoLocation : BaseEntity
    {
        public string Ip { get; set; }
        public string Type { get; set; }
        public string ContinentCode { get; set; }
        public string ContinentName { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public string RegionCode { get; set; }
        public string RegionName { get; set; }
        public virtual ICollection<Location> Locations { get; set; }
    }
}
