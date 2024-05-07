// --------------------------------------------------------------------------------------------------
// <copyright file="PaginatedExtendedAttributeFilterValidator.cs" company="">
// Copyright (c) . All rights reserved.
// The core team: Reza Bashiri.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------

using FluentValidation;
using Microsoft.Extensions.Localization;
using Shared.Core.Contracts;
using Shared.Core.Features.ExtendedAttributes.Filters;
using Shared.Core.Interfaces;

namespace Shared.Core.Features.ExtendedAttributes.Queries.Validators
{
    public abstract class PaginatedExtendedAttributeFilterValidator<TEntityId, TEntity> :
        AbstractValidator<PaginatedExtendedAttributeFilter<TEntityId, TEntity>>,
        IPaginatedFilterValidator<TEntityId, TEntity, PaginatedExtendedAttributeFilter<TEntityId, TEntity>>
            where TEntity : class, IEntity<TEntityId>
    {
        protected PaginatedExtendedAttributeFilterValidator(IStringLocalizer localizer)
        {
            IPaginatedFilterValidator<TEntityId, TEntity, PaginatedExtendedAttributeFilter<TEntityId, TEntity>>.UseRules(this, localizer);
        }
    }
}