// --------------------------------------------------------------------------------------------------
// <copyright file="RemoveExtendedAttributeCommandValidator.cs" company="">
// Copyright (c) . All rights reserved.
// The core team: Reza Bashiri.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------

using System;
using FluentValidation;
using Microsoft.Extensions.Localization;
using Shared.Core.Contracts;

namespace Shared.Core.Features.ExtendedAttributes.Commands.Validators
{
    public abstract class RemoveExtendedAttributeCommandValidator<TEntityId, TEntity> : AbstractValidator<RemoveExtendedAttributeCommand<TEntityId, TEntity>>
        where TEntity : class, IEntity<TEntityId>
    {
        protected RemoveExtendedAttributeCommandValidator(IStringLocalizer localizer)
        {
            RuleFor(request => request.Id)
                .NotEqual(Guid.Empty).WithMessage(_ => localizer["The {PropertyName} property cannot be empty."]);
        }
    }
}