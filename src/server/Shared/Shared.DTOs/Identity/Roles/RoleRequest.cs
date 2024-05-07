// --------------------------------------------------------------------------------------------------
// <copyright file="RoleRequest.cs" company="">
// Copyright (c) . All rights reserved.
// The core team: Reza Bashiri.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------

namespace Shared.DTOs.Identity.Roles
{
    public class RoleRequest
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}