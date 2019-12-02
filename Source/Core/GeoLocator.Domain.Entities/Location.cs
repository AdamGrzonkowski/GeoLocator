using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeoLocator.Domain.Entities
{
    public class Location : BaseEntity
    {
        public string City { get; set; }
        public string ZipCode { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int GeoNameId { get; set; }
        public string Capital { get; set; }
        public string CountryFlagUrl { get; set; }
        public string CountryFlagUniCode { get; set; }
        public string CallingCode { get; set; }
        public bool IsEu { get; set; }
        public Guid? GeoLocationId { get; set; }

        [ForeignKey(nameof(GeoLocationId))]
        public virtual GeoLocation GeoLocation { get; set; }

        public virtual ICollection<Language> Languages { get; set; }
    }
}
