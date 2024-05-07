// --------------------------------------------------------------------------------------------------
// <copyright file="TokensController.cs" company="">
// Copyright (c) . All rights reserved.
// The core team: Reza Bashiri.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------

using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Core.Interfaces.Services.Identity;
using Shared.DTOs.Identity.Tokens;

namespace Modules.Identity.Controllers
{
    [ApiVersion("1")]
    internal sealed class TokensController : BaseController
    {
        private readonly ITokenService _tokenService;

        public TokensController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> GetTokenAsync(TokenRequest request)
        {
            var token = await _tokenService.GetTokenAsync(request, GenerateIPAddress());
            return Ok(token);
        }

        [HttpPost("refresh")]
        [AllowAnonymous]
        public async Task<ActionResult> RefreshAsync(RefreshTokenRequest request)
        {
            var response = await _tokenService.RefreshTokenAsync(request, GenerateIPAddress());
            return Ok(response);
        }

        // ReSharper disable once InconsistentNaming
        private string GenerateIPAddress()
        {
            if (Request.Headers.ContainsKey("X-Forwarded-For"))
            {
                return Request.Headers["X-Forwarded-For"];
            }
            else
            {
                return HttpContext.Connection.RemoteIpAddress?.MapToIPv4().ToString();
            }
        }
    }
}