// --------------------------------------------------------------------------------------------------
// <copyright file="IApplicationDbContext.cs" company="">
// Copyright (c) . All rights reserved.
// The core team: Reza Bashiri.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;
using Shared.Core.Entities;
using Shared.Core.EventLogging;

namespace Shared.Core.Interfaces
{
    public interface IApplicationDbContext : IDbContext
    {
        public DbSet<EventLog> EventLogs { get; set; }

        public DbSet<EntityReference> EntityReferences { get; set; }
    }
}