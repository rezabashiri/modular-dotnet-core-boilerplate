// --------------------------------------------------------------------------------------------------
// <copyright file="ICurrentUser.cs" company="">
// Copyright (c) . All rights reserved.
// The core team: Reza Bashiri.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace Shared.Core.Interfaces.Services.Identity
{
    public interface ICurrentUser
    {
        string Name { get; }

        Guid GetUserId();

        string GetUserEmail();

        bool IsAuthenticated();

        bool IsInRole(string role);

        IEnumerable<Claim> GetUserClaims();

        HttpContext GetHttpContext();
    }
}