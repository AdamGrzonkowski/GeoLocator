using GeoLocator.Domain.Entities;

using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;

namespace GeoLocator.Domain.Services
{
    /// <summary>
    /// Abstraction layer over db context.
    /// </summary>
    public interface IDbContext : IDisposable
    {
        Database Database { get; }
        DbChangeTracker ChangeTracker { get; }
        IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity;
        Task<int> SaveChangesAsync();
        DbEntityEntry Entry(object entity);
    }
}
