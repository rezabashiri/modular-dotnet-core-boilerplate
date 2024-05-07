// --------------------------------------------------------------------------------------------------
// <copyright file="RoleUpdatedEvent.cs" company="">
// Copyright (c) . All rights reserved.
// The core team: Reza Bashiri.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------

using System;
using Modules.Identity.Core.Entities;
using Shared.Core.Domain;

namespace Modules.Identity.Core.Features.Roles.Events
{
    public class RoleUpdatedEvent : Event
    {
        public string Id { get; }

        public string Name { get; }

        public string Description { get; }

        public RoleUpdatedEvent(BoilerplateRole role)
        {
            Name = role.Name;
            Description = role.Description;
            Id = role.Id;
            AggregateId = Guid.TryParse(role.Id, out var aggregateId)
                ? aggregateId
                : Guid.NewGuid();
            RelatedEntities = new[] { typeof(BoilerplateRole) };
        }
    }
}