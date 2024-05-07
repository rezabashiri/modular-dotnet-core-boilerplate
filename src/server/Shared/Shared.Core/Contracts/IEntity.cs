// --------------------------------------------------------------------------------------------------
// <copyright file="IEntity.cs" company="">
// Copyright (c) . All rights reserved.
// The core team: Reza Bashiri.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------

namespace Shared.Core.Contracts
{
    public interface IEntity<TEntityId> : IEntity
    {
        public TEntityId Id { get; set; }
    }

    public interface IEntity
    {
    }
}