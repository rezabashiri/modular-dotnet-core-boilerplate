// --------------------------------------------------------------------------------------------------
// <copyright file="RefreshTokenRequest.cs" company="">
// Copyright (c) . All rights reserved.
// The core team: Reza Bashiri.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------

namespace Shared.DTOs.Identity.Tokens
{
    public record RefreshTokenRequest(string Token, string RefreshToken);
}