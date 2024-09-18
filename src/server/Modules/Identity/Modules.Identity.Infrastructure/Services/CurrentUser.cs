// --------------------------------------------------------------------------------------------------
// <copyright file="CurrentUser.cs" company="">
// Copyright (c) . All rights reserved.
// The core team: Reza Bashiri.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Modules.Identity.Infrastructure.Extensions;
using Shared.Core.Interfaces.Services.Identity;

namespace Modules.Identity.Infrastructure.Services
{
    public class CurrentUser(IHttpContextAccessor accessor) : ICurrentUser
    {
        public string Name => accessor.HttpContext?.User.Identity?.Name;

        public Guid GetUserId()
        {
            return IsAuthenticated() ? Guid.Parse(accessor.HttpContext?.User.GetUserId() ?? Guid.Empty.ToString()) : Guid.Empty;
        }

        public string GetUserEmail()
        {
            return IsAuthenticated() ? accessor.HttpContext?.User.GetUserEmail() : string.Empty;
        }

        public bool IsAuthenticated()
        {
            return accessor.HttpContext?.User.Identity?.IsAuthenticated ?? false;
        }

        public bool IsInRole(string role)
        {
            return accessor.HttpContext?.User.IsInRole(role) ?? false;
        }

        public IEnumerable<Claim> GetUserClaims()
        {
            return accessor.HttpContext?.User.Claims;
        }

        public HttpContext GetHttpContext()
        {
            return accessor.HttpContext;
        }
    }
}