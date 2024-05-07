// --------------------------------------------------------------------------------------------------
// <copyright file="EventLogProfile.cs" company="">
// Copyright (c) . All rights reserved.
// The core team: Reza Bashiri.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------

using AutoMapper;
using Shared.Core.EventLogging;
using Shared.Core.Mappings.Converters;
using Shared.DTOs.Identity.EventLogs;

namespace Shared.Infrastructure.Mappings
{
    public class EventLogProfile : Profile
    {
        public EventLogProfile()
        {
            CreateMap<PaginatedEventLogsFilter, GetEventLogsRequest>()
                .ForMember(dest => dest.OrderBy, opt => opt.ConvertUsing<string>(new OrderByConverter()));
            CreateMap<LogEventRequest, EventLog>().ReverseMap();
        }
    }
}