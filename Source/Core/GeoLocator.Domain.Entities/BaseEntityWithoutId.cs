using System;

namespace GeoLocator.Domain.Entities
{
    public abstract class BaseEntityWithoutId
    {
        /// <summary>
        /// Datetime of creation.
        /// </summary>
        public DateTime CreatedTs { get; set; }

        /// <summary>
        /// Indicates whether object is deleted.
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}
