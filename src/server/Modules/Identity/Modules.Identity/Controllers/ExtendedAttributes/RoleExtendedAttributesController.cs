// --------------------------------------------------------------------------------------------------
// <copyright file="RoleExtendedAttributesController.cs" company="">
// Copyright (c) . All rights reserved.
// The core team: Reza Bashiri.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Modules.Identity.Core.Entities;
using Shared.Core.Constants;
using Shared.Core.Domain;
using Shared.Core.Features.Common.Filters;
using Shared.Core.Features.ExtendedAttributes.Commands;
using Shared.Core.Features.ExtendedAttributes.Filters;
using Shared.Infrastructure.Controllers;

namespace Modules.Identity.Controllers.ExtendedAttributes
{
    [ApiVersion("1")]
    [Route(BaseController.BasePath + "/role/attributes")]
    internal sealed class RoleExtendedAttributesController : ExtendedAttributesController<string, BoilerplateRole>
    {
        [Authorize(Policy = Permissions.RolesExtendedAttributes.ViewAll)]
        public override Task<IActionResult> GetAllAsync(PaginatedExtendedAttributeFilter<string, BoilerplateRole> filter)
        {
            return base.GetAllAsync(filter);
        }

        [Authorize(Policy = Permissions.RolesExtendedAttributes.View)]
        public override Task<IActionResult> GetByIdAsync([FromQuery] GetByIdCacheableFilter<Guid, ExtendedAttribute<string, BoilerplateRole>> filter)
        {
            return base.GetByIdAsync(filter);
        }

        [Authorize(Policy = Permissions.RolesExtendedAttributes.Add)]
        public override Task<IActionResult> CreateAsync(AddExtendedAttributeCommand<string, BoilerplateRole> command)
        {
            return base.CreateAsync(command);
        }

        [Authorize(Policy = Permissions.RolesExtendedAttributes.Update)]
        public override Task<IActionResult> UpdateAsync(UpdateExtendedAttributeCommand<string, BoilerplateRole> command)
        {
            return base.UpdateAsync(command);
        }

        [Authorize(Policy = Permissions.RolesExtendedAttributes.Remove)]
        public override Task<IActionResult> RemoveAsync(Guid id)
        {
            return base.RemoveAsync(id);
        }
    }
}