// --------------------------------------------------------------------------------------------------
// <copyright file="IExtendedAttributeDbContext.cs" company="">
// Copyright (c) . All rights reserved.
// The core team: Reza Bashiri.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Shared.Core.Contracts;
using Shared.Core.Domain;

namespace Shared.Core.Interfaces
{
    public interface IExtendedAttributeDbContext<TEntityId, TEntity, TExtendedAttribute> : IDbContext
        where TEntity : class, IEntity<TEntityId>
        where TExtendedAttribute : ExtendedAttribute<TEntityId, TEntity>
    {
        [NotMapped]
        public DbSet<TEntity> Entities => GetEntities();

        protected DbSet<TEntity> GetEntities();

        public DbSet<TExtendedAttribute> ExtendedAttributes { get; set; }
    }
}