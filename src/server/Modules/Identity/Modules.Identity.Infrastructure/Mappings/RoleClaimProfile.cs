// --------------------------------------------------------------------------------------------------
// <copyright file="RoleClaimProfile.cs" company="">
// Copyright (c) . All rights reserved.
// The core team: Reza Bashiri.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------

using AutoMapper;
using Modules.Identity.Core.Entities;
using Shared.DTOs.Identity.Roles;

namespace Modules.Identity.Infrastructure.Mappings
{
    public class RoleClaimProfile : Profile
    {
        public RoleClaimProfile()
        {
            CreateMap<RoleClaimResponse, RoleClaim>()
                .ForMember(nameof(RoleClaim.ClaimType), opt => opt.MapFrom(c => c.Type))
                .ForMember(nameof(RoleClaim.ClaimValue), opt => opt.MapFrom(c => c.Value))
                .ReverseMap();

            CreateMap<RoleClaimRequest, RoleClaim>()
                .ForMember(nameof(RoleClaim.ClaimType), opt => opt.MapFrom(c => c.Type))
                .ForMember(nameof(RoleClaim.ClaimValue), opt => opt.MapFrom(c => c.Value))
                .ReverseMap();

            CreateMap<RoleClaimModel, RoleClaimRequest>();
            CreateMap<RoleClaimModel, RoleClaim>().ReverseMap();
            CreateMap<RoleClaimModel, RoleClaimResponse>().ReverseMap();
        }
    }
}