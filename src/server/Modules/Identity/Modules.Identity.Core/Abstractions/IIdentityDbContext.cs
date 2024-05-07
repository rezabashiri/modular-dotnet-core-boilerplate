// --------------------------------------------------------------------------------------------------
// <copyright file="IIdentityDbContext.cs" company="">
// Copyright (c) . All rights reserved.
// The core team: Reza Bashiri.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;
using Modules.Identity.Core.Entities;
using Shared.Core.Interfaces;

namespace Modules.Identity.Core.Abstractions
{
    public interface IIdentityDbContext : IDbContext
    {
        public DbSet<BoilerplateUser> Users { get; set; }

        public DbSet<BoilerplateRole> Roles { get; set; }

        public DbSet<RoleClaim> RoleClaims { get; set; }
    }
}