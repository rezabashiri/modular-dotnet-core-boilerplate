// --------------------------------------------------------------------------------------------------
// <copyright file="UserLoggedInEvent.cs" company="">
// Copyright (c) . All rights reserved.
// The core team: Reza Bashiri.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------

using System;
using Modules.Identity.Core.Entities;
using Shared.Core.Domain;

namespace Modules.Identity.Core.Events
{
    public class UserLoggedInEvent : Event
    {
        public Guid UserId { get; }

        public new DateTime Timestamp { get; }

        public UserLoggedInEvent(Guid userId)
        {
            UserId = userId;
            Timestamp = DateTime.Now;
            AggregateId = userId;
            RelatedEntities = new[] { typeof(BoilerplateUser) };
        }
    }
}