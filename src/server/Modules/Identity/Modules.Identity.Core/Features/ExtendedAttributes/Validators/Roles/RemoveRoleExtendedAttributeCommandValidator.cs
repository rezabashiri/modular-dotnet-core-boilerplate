// --------------------------------------------------------------------------------------------------
// <copyright file="RemoveRoleExtendedAttributeCommandValidator.cs" company="">
// Copyright (c) . All rights reserved.
// The core team: Reza Bashiri.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------

using Microsoft.Extensions.Localization;
using Modules.Identity.Core.Entities;
using Shared.Core.Features.ExtendedAttributes.Commands.Validators;

namespace Modules.Identity.Core.Features.ExtendedAttributes.Validators.Roles
{
    public class RemoveRoleExtendedAttributeCommandValidator : RemoveExtendedAttributeCommandValidator<string, BoilerplateRole>
    {
        public RemoveRoleExtendedAttributeCommandValidator(IStringLocalizer<RemoveRoleExtendedAttributeCommandValidator> localizer)
            : base(localizer)
        {
            // you can override the validation rules here
        }
    }
}