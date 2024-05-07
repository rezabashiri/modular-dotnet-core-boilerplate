// --------------------------------------------------------------------------------------------------
// <copyright file="IUserService.cs" company="">
// Copyright (c) . All rights reserved.
// The core team: Reza Bashiri.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using Shared.Core.Wrapper;
using Shared.DTOs.Identity.Users;

namespace Modules.Identity.Core.Abstractions
{
    public interface IUserService
    {
        Task<Result<List<UserResponse>>> GetAllAsync();

        Task<IResult<UserResponse>> GetAsync(string userId);

        Task<IResult<UserRolesResponse>> GetRolesAsync(string userId);

        Task<IResult<string>> UpdateAsync(UpdateUserRequest request);

        Task<IResult<string>> UpdateUserRolesAsync(string userId, UserRolesRequest request);
    }
}