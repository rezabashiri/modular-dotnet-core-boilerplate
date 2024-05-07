// --------------------------------------------------------------------------------------------------
// <copyright file="RoleClaimDeletedEvent.cs" company="">
// Copyright (c) . All rights reserved.
// The core team: Reza Bashiri.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------

using System;
using Modules.Identity.Core.Entities;
using Shared.Core.Domain;

namespace Modules.Identity.Core.Features.RoleClaims.Events
{
    public class RoleClaimDeletedEvent : Event
    {
        public int Id { get; }

        public RoleClaimDeletedEvent(int id)
        {
            Id = id;
            AggregateId = Guid.NewGuid();
            RelatedEntities = new[] { typeof(RoleClaim) };
        }
    }
}