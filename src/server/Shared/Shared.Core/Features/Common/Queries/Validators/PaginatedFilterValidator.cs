// --------------------------------------------------------------------------------------------------
// <copyright file="PaginatedFilterValidator.cs" company="">
// Copyright (c) . All rights reserved.
// The core team: Reza Bashiri.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------

using FluentValidation;
using Microsoft.Extensions.Localization;
using Shared.Core.Contracts;
using Shared.Core.Interfaces;
using Shared.DTOs.Filters;

namespace Shared.Core.Features.Common.Queries.Validators
{
    public abstract class PaginatedFilterValidator<TEntityId, TEntity, TFilter> :
        AbstractValidator<TFilter>,
        IPaginatedFilterValidator<TEntityId, TEntity, TFilter>
            where TEntity : class, IEntity<TEntityId>
            where TFilter : PaginatedFilter
    {
        protected PaginatedFilterValidator(IStringLocalizer localizer)
        {
            IPaginatedFilterValidator<TEntityId, TEntity, TFilter>.UseRules(this, localizer);
        }
    }
}