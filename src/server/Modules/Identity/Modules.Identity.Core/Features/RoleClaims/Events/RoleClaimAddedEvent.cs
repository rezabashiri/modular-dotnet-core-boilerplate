// --------------------------------------------------------------------------------------------------
// <copyright file="RoleClaimAddedEvent.cs" company="">
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
    public class RoleClaimAddedEvent : Event
    {
        public int Id { get; }

        public string RoleId { get; }

        public string ClaimType { get; }

        public string ClaimValue { get; }

        public string Group { get; }

        public string Description { get; }

        public RoleClaimAddedEvent(RoleClaim roleClaim)
        {
            RoleId = roleClaim.RoleId;
            Group = roleClaim.Group;
            ClaimType = roleClaim.ClaimType;
            ClaimValue = roleClaim.ClaimValue;
            Description = roleClaim.Description;
            Id = roleClaim.Id;
            AggregateId = Guid.NewGuid();
            RelatedEntities = new[] { typeof(RoleClaim) };
        }
    }
}