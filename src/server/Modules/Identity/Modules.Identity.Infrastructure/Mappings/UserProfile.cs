// --------------------------------------------------------------------------------------------------
// <copyright file="UserProfile.cs" company="">
// Copyright (c) . All rights reserved.
// The core team: Reza Bashiri.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------

using AutoMapper;
using Modules.Identity.Core.Entities;
using Shared.DTOs.Identity.Users;

namespace Modules.Identity.Infrastructure.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserResponse, BoilerplateUser>().ReverseMap();
            CreateMap<UpdateUserRequest, BoilerplateUser>().ReverseMap();
        }
    }
}