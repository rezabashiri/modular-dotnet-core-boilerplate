// --------------------------------------------------------------------------------------------------
// <copyright file="UserRolesResponse.cs" company="">
// Copyright (c) . All rights reserved.
// The core team: Reza Bashiri.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace Shared.DTOs.Identity.Users
{
    public class UserRolesResponse
    {
        public List<UserRoleModel> UserRoles { get; set; } = new();
    }

    public class UserRoleModel
    {
        public string RoleId { get; set; }

        public string RoleName { get; set; }

        public bool Selected { get; set; }
    }
}