// --------------------------------------------------------------------------------------------------
// <copyright file="ExtendedAttributeRemovedEvent.cs" company="">
// Copyright (c) . All rights reserved.
// The core team: Reza Bashiri.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------

using System;
using Shared.Core.Domain;
using Shared.Core.Utilities;

namespace Shared.Core.Features.ExtendedAttributes.Events
{
    public class ExtendedAttributeRemovedEvent<TEntityId, TEntity> : Event
    {
        public Guid Id { get; }

        public string EntityName { get; set; }

        public ExtendedAttributeRemovedEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
            EntityName = typeof(TEntity).GetGenericTypeName();
            RelatedEntities = new[] { typeof(TEntity) };
        }
    }
}