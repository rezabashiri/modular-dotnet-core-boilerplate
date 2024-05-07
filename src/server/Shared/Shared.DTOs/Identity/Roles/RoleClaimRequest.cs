// --------------------------------------------------------------------------------------------------
// <copyright file="RoleClaimRequest.cs" company="">
// Copyright (c) . All rights reserved.
// The core team: Reza Bashiri.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------

namespace Shared.DTOs.Identity.Roles
{
    public class RoleClaimRequest
    {
        public int Id { get; set; }

        public string RoleId { get; set; }

        public string Type { get; set; }

        public string Value { get; set; }

        public string Description { get; set; }

        public string Group { get; set; }
    }
}