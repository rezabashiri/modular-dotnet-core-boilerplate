// --------------------------------------------------------------------------------------------------
// <copyright file="RemoveExtendedAttributeCommand.cs" company="">
// Copyright (c) . All rights reserved.
// The core team: Reza Bashiri.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------

using System;
using MediatR;
using Shared.Core.Contracts;
using Shared.Core.Wrapper;

namespace Shared.Core.Features.ExtendedAttributes.Commands
{
    // ReSharper disable once UnusedTypeParameter
    public class RemoveExtendedAttributeCommand<TEntityId, TEntity> : IRequest<Result<Guid>>
        where TEntity : class, IEntity<TEntityId>
    {
        public Guid Id { get; }

        public RemoveExtendedAttributeCommand(Guid entityExtendedAttributeId)
        {
            Id = entityExtendedAttributeId;
        }
    }
}