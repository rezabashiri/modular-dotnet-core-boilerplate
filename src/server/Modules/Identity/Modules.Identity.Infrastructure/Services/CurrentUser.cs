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
    public class CurrentUser : ICurrentUser
    {
        private readonly IHttpContextAccessor _accessor;

        public CurrentUser(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public string Name => _accessor.HttpContext?.User.Identity?.Name;

        public Guid GetUserId()
        {
            return IsAuthenticated() ? Guid.Parse(_accessor.HttpContext?.User.GetUserId() ?? Guid.Empty.ToString()) : Guid.Empty;
        }

        public string GetUserEmail()
        {
            return IsAuthenticated() ? _accessor.HttpContext?.User.GetUserEmail() : string.Empty;
        }

        public bool IsAuthenticated()
        {
            return _accessor.HttpContext?.User.Identity?.IsAuthenticated ?? false;
        }

        public bool IsInRole(string role)
        {
            return _accessor.HttpContext?.User.IsInRole(role) ?? false;
        }

        public IEnumerable<Claim> GetUserClaims()
        {
            return _accessor.HttpContext?.User.Claims;
        }

        public HttpContext GetHttpContext()
        {
            return _accessor.HttpContext;
        }
    }
}