using GeoLocator.Domain.Entities;
using GeoLocator.Domain.Services.Interfaces.Base;

using System;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GeoLocator.Domain.Services.Base
{
    /// <inheritdoc />
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly IDbContext _context;

        /// <inheritdoc />
        protected BaseRepository(IDbContext context)
        {
            _context = context;
        }

        private IDbSet<TEntity> Entities => _context.Set<TEntity>();

        /// <inheritdoc />
        public async Task<bool> DeleteAsync(Guid id)
        {
            TEntity entity = Entities.Create<TEntity>();
            entity.Id = id;
            Entities.Attach(entity);

            Entities.Remove(entity);

            return await _context.SaveChangesAsync()
                .ConfigureAwait(false) > 0;
        }

        /// <inheritdoc />
        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await Entities
                .FirstOrDefaultAsync(filter)
                .ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<Guid> InsertAsync(TEntity entity)
        {
            entity.CreatedTs = DateTime.UtcNow;
            Entities.Add(entity);

            await _context.SaveChangesAsync()
                .ConfigureAwait(false);

            return entity.Id;
        }
    }
}
