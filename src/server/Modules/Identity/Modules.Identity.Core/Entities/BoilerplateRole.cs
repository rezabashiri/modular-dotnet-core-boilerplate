// --------------------------------------------------------------------------------------------------
// <copyright file="BoilerplateRole.cs" company="">
// Copyright (c) . All rights reserved.
// The core team: Reza Bashiri.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Modules.Identity.Core.Entities.ExtendedAttributes;
using Shared.Core.Contracts;
using Shared.Core.Domain;

namespace Modules.Identity.Core.Entities
{
    public class BoilerplateRole : IdentityRole, IEntity<string>, IBaseEntity
    {
        public string Description { get; set; }

        public virtual ICollection<RoleClaim> RoleClaims { get; set; }

        public virtual ICollection<RoleExtendedAttribute> ExtendedAttributes { get; set; }

        private List<Event> _domainEvents;

        public IReadOnlyCollection<Event> DomainEvents => _domainEvents?.AsReadOnly();

        public void AddDomainEvent(Event domainEvent)
        {
            _domainEvents ??= new List<Event>();
            _domainEvents.Add(domainEvent);
        }

        public void RemoveDomainEvent(Event domainEvent)
        {
            _domainEvents?.Remove(domainEvent);
        }

        public void ClearDomainEvents()
        {
            _domainEvents?.Clear();
        }

        public BoilerplateRole()
            : base()
        {
            RoleClaims = new HashSet<RoleClaim>();
            ExtendedAttributes = new HashSet<RoleExtendedAttribute>();
        }

        public BoilerplateRole(string roleName, string roleDescription = null)
            : base(roleName)
        {
            RoleClaims = new HashSet<RoleClaim>();
            ExtendedAttributes = new HashSet<RoleExtendedAttribute>();
            Description = roleDescription;
        }
    }
}