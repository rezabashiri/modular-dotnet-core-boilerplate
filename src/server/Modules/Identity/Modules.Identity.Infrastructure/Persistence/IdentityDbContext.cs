// --------------------------------------------------------------------------------------------------
// <copyright file="IdentityDbContext.cs" company="">
// Copyright (c) . All rights reserved.
// The core team: Reza Bashiri.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Options;
using Modules.Identity.Core.Abstractions;
using Modules.Identity.Core.Entities;
using Modules.Identity.Core.Entities.ExtendedAttributes;
using Modules.Identity.Infrastructure.Extensions;
using Shared.Core.Domain;
using Shared.Core.EventLogging;
using Shared.Core.Interfaces;
using Shared.Core.Interfaces.Serialization;
using Shared.Core.Settings;
using Shared.Infrastructure.Extensions;

namespace Modules.Identity.Infrastructure.Persistence
{
    public sealed class IdentityDbContext : IdentityDbContext<BoilerplateUser, BoilerplateRole, string, IdentityUserClaim<string>, IdentityUserRole<string>, IdentityUserLogin<string>, RoleClaim, IdentityUserToken<string>>,
        IIdentityDbContext,
        IModuleDbContext,
        IExtendedAttributeDbContext<string, BoilerplateUser, UserExtendedAttribute>,
        IExtendedAttributeDbContext<string, BoilerplateRole, RoleExtendedAttribute>
    {
        private readonly IMediator _mediator;
        private readonly IEventLogger _eventLogger;
        private readonly PersistenceSettings _persistenceOptions;
        private readonly IJsonSerializer _json;

        internal string Schema => "Identity";

        public IdentityDbContext(
            DbContextOptions<IdentityDbContext> options,
            IOptions<PersistenceSettings> persistenceOptions,
            IMediator mediator,
            IEventLogger eventLogger,
            IJsonSerializer json)
                : base(options)
        {
            _mediator = mediator;
            _eventLogger = eventLogger;
            _persistenceOptions = persistenceOptions.Value;
            _json = json;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(Schema);
            modelBuilder.Ignore<Event>();
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            modelBuilder.ApplyIdentityConfiguration(_persistenceOptions);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var changes = OnBeforeSaveChanges();
            return await this.SaveChangeWithPublishEventsAsync(_eventLogger, _mediator, changes, _json, cancellationToken);
        }

        private List<(EntityEntry entityEntry, string oldValues, string newValues)> OnBeforeSaveChanges()
        {
            var result = new List<(EntityEntry entityEntry, string oldValues, string newValues)>();
            ChangeTracker.DetectChanges();
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.State == EntityState.Unchanged)
                {
                    continue;
                }

                var previousData = new Dictionary<string, object>();
                var currentData = new Dictionary<string, object>();
                foreach (var property in entry.Properties)
                {
                    string propertyName = property.Metadata.Name;
                    object originalValue = entry.GetDatabaseValues()?.GetValue<object>(propertyName);
                    switch (entry.State)
                    {
                        case EntityState.Unchanged:
                            break;
                        case EntityState.Added:
                            currentData[propertyName] = property.CurrentValue;
                            break;
                        case EntityState.Deleted:
                            previousData[propertyName] = originalValue;
                            break;

                        case EntityState.Modified:
                            if (property.IsModified && originalValue?.Equals(property.CurrentValue) == false)
                            {
                                previousData[propertyName] = originalValue;
                                currentData[propertyName] = property.CurrentValue;
                            }

                            break;
                    }
                }

                string oldValues = previousData.Count == 0 ? null : _json.Serialize(previousData);
                string newValues = currentData.Count == 0 ? null : _json.Serialize(currentData);
                result.Add((entry, oldValues, newValues));
            }

            return result;
        }

        public override int SaveChanges()
        {
            var changes = OnBeforeSaveChanges();
            return this.SaveChangeWithPublishEvents(_eventLogger, _mediator, changes, _json);
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            return SaveChanges();
        }

        DbSet<BoilerplateUser> IExtendedAttributeDbContext<string, BoilerplateUser, UserExtendedAttribute>.GetEntities() => Users;

        DbSet<UserExtendedAttribute> IExtendedAttributeDbContext<string, BoilerplateUser, UserExtendedAttribute>.ExtendedAttributes { get; set; }

        DbSet<BoilerplateRole> IExtendedAttributeDbContext<string, BoilerplateRole, RoleExtendedAttribute>.GetEntities() => Roles;

        DbSet<RoleExtendedAttribute> IExtendedAttributeDbContext<string, BoilerplateRole, RoleExtendedAttribute>.ExtendedAttributes { get; set; }
    }
}