using System.Collections.Generic;

namespace GeoLocator.Domain.Entities
{
    public class Language : BaseEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Native { get; set; }

        public virtual ICollection<Location> Locations { get; set; }
    }
}
