using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeoLocator.Domain.Entities
{
    public class LocationLanguage
    {
        [Key, Column(Order = 0)]
        public Guid LocationId { get; set; }
        [Key, Column(Order = 1)]
        public Guid LanguageId { get; set; }

        public virtual Location Location { get; set; }
        public virtual Language Language { get; set; }
    }
}
