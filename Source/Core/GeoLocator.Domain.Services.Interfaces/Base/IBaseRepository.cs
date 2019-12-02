using GeoLocator.Domain.Entities;

using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GeoLocator.Domain.Services.Interfaces.Base
{
    /// <summary>
    /// Abstraction for base repository.
    /// </summary>
    /// <typeparam name="TEntity">Entity class type, deriving from BaseEntity</typeparam>
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        /// <summary>
        /// Finds entity based on the passed filter expression.
        /// </summary>
        /// <param name="filter">Filter expression.</param>
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter);

        /// <summary>
        /// Adds record to the list of entities to be persisted after committing changes.
        /// </summary>
        /// <param name="entity">Entity to be added.</param>
        Task<Guid> InsertAsync(TEntity entity);

        /// <summary>
        /// Deletes entity.
        /// </summary>
        /// <param name="id">Id of entity to be deleted.</param>
        Task<bool> DeleteAsync(Guid id);
    }
}
