// --------------------------------------------------------------------------------------------------
// <copyright file="PaginatedUserExtendedAttributeFilterValidator.cs" company="">
// Copyright (c) . All rights reserved.
// The core team: Reza Bashiri.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------

using Microsoft.Extensions.Localization;
using Modules.Identity.Core.Entities;
using Shared.Core.Features.ExtendedAttributes.Queries.Validators;

namespace Modules.Identity.Core.Features.ExtendedAttributes.Validators.Users
{
    public class PaginatedUserExtendedAttributeFilterValidator : PaginatedExtendedAttributeFilterValidator<string, BoilerplateUser>
    {
        public PaginatedUserExtendedAttributeFilterValidator(IStringLocalizer<PaginatedUserExtendedAttributeFilterValidator> localizer)
            : base(localizer)
        {
            // you can override the validation rules here
        }
    }
}