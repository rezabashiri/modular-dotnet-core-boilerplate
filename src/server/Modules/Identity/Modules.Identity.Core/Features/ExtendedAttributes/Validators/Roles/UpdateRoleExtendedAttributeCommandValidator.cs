// --------------------------------------------------------------------------------------------------
// <copyright file="UpdateRoleExtendedAttributeCommandValidator.cs" company="">
// Copyright (c) . All rights reserved.
// The core team: Reza Bashiri.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------

using Microsoft.Extensions.Localization;
using Modules.Identity.Core.Entities;
using Shared.Core.Features.ExtendedAttributes.Commands.Validators;
using Shared.Core.Interfaces.Serialization;

namespace Modules.Identity.Core.Features.ExtendedAttributes.Validators.Roles
{
    public class UpdateRoleExtendedAttributeCommandValidator : UpdateExtendedAttributeCommandValidator<string, BoilerplateRole>
    {
        public UpdateRoleExtendedAttributeCommandValidator(IStringLocalizer<UpdateRoleExtendedAttributeCommandValidator> localizer, IJsonSerializer jsonSerializer)
            : base(localizer, jsonSerializer)
        {
            // you can override the validation rules here
        }
    }
}