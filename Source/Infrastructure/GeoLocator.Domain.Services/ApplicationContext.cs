﻿using GeoLocator.Domain.Entities;

using System;
using System.Configuration;
using System.Data.Common;
using System.Data.Entity;

namespace GeoLocator.Domain.Services
{
    public sealed class ApplicationContext : DbContext, IDbContext
    {
        private volatile Type _dependency;

        public DbSet<GeoLocation> GeoLocations { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Language> Languages { get; set; }

        /// <summary>
        /// Constructor used in the web app.
        /// </summary>
        public ApplicationContext() : base(ConfigurationManager.ConnectionStrings["LocalHostDb"].ConnectionString)
        {
            FixProviderError();
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationContext, Migrations.Configuration>());
        }

        /// <summary>
        /// Constructor used in unit tests by Effort.
        /// </summary>
        /// <param name="connection"></param>
        public ApplicationContext(DbConnection connection) : base(connection, true)
        {
            FixProviderError();
            Database.CreateIfNotExists();
        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        {
            return base.Set<TEntity>();
        }

        /// <summary>
        /// Fixes EntityFramework provider. 
        /// </summary>
        /// <remarks>
        /// Only assemblies that are used directly get copied. EntityFramework.SqlServer assembly has no direct 
        /// reference so does not get copied to other projects.
        /// Explicit reference needs to be created, so that EntityFramework.SqlServer.dll is copied along 
        /// with EntityFramework.dll when needed.
        /// </remarks>
        private void FixProviderError()
        {
            _dependency = typeof(System.Data.Entity.SqlServer.SqlProviderServices);
        }
    }
}
