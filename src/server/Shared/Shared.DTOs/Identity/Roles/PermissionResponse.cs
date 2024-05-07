// --------------------------------------------------------------------------------------------------
// <copyright file="PermissionResponse.cs" company="">
// Copyright (c) . All rights reserved.
// The core team: Reza Bashiri.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace Shared.DTOs.Identity.Roles
{
    public class PermissionResponse
    {
        public string RoleId { get; set; }

        public string RoleName { get; set; }

        public List<RoleClaimModel> RoleClaims { get; set; }
    }
}