// --------------------------------------------------------------------------------------------------
// <copyright file="UserRolesRequest.cs" company="">
// Copyright (c) . All rights reserved.
// The core team: Reza Bashiri.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace Shared.DTOs.Identity.Users
{
    public class UserRolesRequest
    {
        public List<UserRoleModel> UserRoles { get; set; } = new();
    }
}