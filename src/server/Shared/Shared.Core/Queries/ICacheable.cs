// --------------------------------------------------------------------------------------------------
// <copyright file="ICacheable.cs" company="">
// Copyright (c) . All rights reserved.
// The core team: Reza Bashiri.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------

using System;

namespace Shared.Core.Queries
{
    public interface ICacheable
    {
        bool BypassCache { get; }

        string CacheKey { get; }

        TimeSpan? SlidingExpiration { get; }
    }
}