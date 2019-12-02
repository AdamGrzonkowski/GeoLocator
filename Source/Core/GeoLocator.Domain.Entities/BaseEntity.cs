using System;
using System.ComponentModel.DataAnnotations;

namespace GeoLocator.Domain.Entities
{
    public abstract class BaseEntity : BaseEntityWithoutId
    {
        /// <summary>
        /// Id of entity.
        /// </summary>
        [Key]
        public Guid Id { get; set; }
    }
}
