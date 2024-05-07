// --------------------------------------------------------------------------------------------------
// <copyright file="UserUpdatedEvent.cs" company="">
// Copyright (c) . All rights reserved.
// The core team: Reza Bashiri.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------

using System;
using Modules.Identity.Core.Entities;
using Shared.Core.Domain;

namespace Modules.Identity.Core.Features.Users.Events
{
    public class UserUpdatedEvent : Event
    {
        public string Id { get; }

        public string FirstName { get; }

        public string LastName { get; }

        public string Email { get; }

        public string UserName { get; }

        public string PhoneNumber { get; }

        public UserUpdatedEvent(BoilerplateUser user)
        {
            FirstName = user.FirstName;
            LastName = user.LastName;
            Email = user.Email;
            UserName = user.UserName;
            PhoneNumber = user.PhoneNumber;
            Id = user.Id;
            AggregateId = Guid.TryParse(user.Id, out var aggregateId)
                ? aggregateId
                : Guid.NewGuid();
            RelatedEntities = new[] { typeof(BoilerplateUser) };
        }
    }
}