// --------------------------------------------------------------------------------------------------
// <copyright file="TokenRequest.cs" company="">
// Copyright (c) . All rights reserved.
// The core team: Reza Bashiri.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------

namespace Shared.DTOs.Identity.Tokens
{
    public record TokenRequest(string Email, string Password);
}