// --------------------------------------------------------------------------------------------------
// <copyright file="RoleClaim.cs" company="">
// Copyright (c) . All rights reserved.
// The core team: Reza Bashiri.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Shared.Core.Contracts;
using Shared.Core.Domain;

namespace Modules.Identity.Core.Entities
{
    public class RoleClaim : IdentityRoleClaim<string>, IBaseEntity
    {
        public string Description { get; set; }

        public string Group { get; set; }

        public virtual BoilerplateRole Role { get; set; }

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

        public RoleClaim()
            : base()
        {
        }

        public RoleClaim(string roleClaimDescription = null, string roleClaimGroup = null)
            : base()
        {
            Description = roleClaimDescription;
            Group = roleClaimGroup;
        }
    }
}