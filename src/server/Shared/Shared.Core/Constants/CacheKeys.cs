// --------------------------------------------------------------------------------------------------
// <copyright file="CacheKeys.cs" company="">
// Copyright (c) . All rights reserved.
// The core team: Reza Bashiri.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------

using Shared.Core.Contracts;
using Shared.Core.Utilities;

namespace Shared.Core.Constants
{
    public static class CacheKeys
    {
        public static class Common
        {
            public static string GetEntityByIdCacheKey<TEntityId, TEntity>(TEntityId id)
                where TEntity : class, IEntity<TEntityId>
            {
                return $"GetEntity-{typeof(TEntity).GetGenericTypeName()}-{id}";
            }
        }
    }
}