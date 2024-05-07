// --------------------------------------------------------------------------------------------------
// <copyright file="ResetPasswordRequest.cs" company="">
// Copyright (c) . All rights reserved.
// The core team: Reza Bashiri.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------

namespace Shared.DTOs.Identity
{
    public class ResetPasswordRequest
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string Token { get; set; }
    }
}