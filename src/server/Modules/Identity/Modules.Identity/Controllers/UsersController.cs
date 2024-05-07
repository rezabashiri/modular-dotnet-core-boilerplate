// --------------------------------------------------------------------------------------------------
// <copyright file="UsersController.cs" company="">
// Copyright (c) . All rights reserved.
// The core team: Reza Bashiri.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------

using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Modules.Identity.Core.Abstractions;
using Shared.Core.Constants;
using Shared.DTOs.Identity.Users;

namespace Modules.Identity.Controllers
{
    [ApiVersion("1")]
    internal sealed class UsersController : BaseController
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Authorize(Policy = Permissions.Users.View)]
        public async Task<IActionResult> GetAllAsync()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        [Authorize(Policy = Permissions.Users.View)]
        public async Task<IActionResult> GetByIdAsync(string id)
        {
            var user = await _userService.GetAsync(id);
            return Ok(user);
        }

        [HttpPut]
        [Authorize(Policy = Permissions.Users.Edit)]
        public async Task<IActionResult> UpdateAsync(UpdateUserRequest request)
        {
            var user = await _userService.UpdateAsync(request);
            return Ok(user);
        }

        [HttpGet("roles/{id}")]
        [Authorize(Policy = Permissions.Users.View)]
        public async Task<IActionResult> GetRolesAsync(string id)
        {
            var userRoles = await _userService.GetRolesAsync(id);
            return Ok(userRoles);
        }

        [HttpPut("roles/{id}")]
        [Authorize(Policy = Permissions.Users.Edit)]
        public async Task<IActionResult> UpdateUserRolesAsync(string id, UserRolesRequest request)
        {
            var result = await _userService.UpdateUserRolesAsync(id, request);
            return Ok(result);
        }
    }
}