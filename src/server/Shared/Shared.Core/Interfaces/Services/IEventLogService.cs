// --------------------------------------------------------------------------------------------------
// <copyright file="IEventLogService.cs" company="">
// Copyright (c) . All rights reserved.
// The core team: Reza Bashiri.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------

using System.Threading.Tasks;
using Shared.Core.EventLogging;
using Shared.Core.Wrapper;
using Shared.DTOs.Identity.EventLogs;

namespace Shared.Core.Interfaces.Services
{
    public interface IEventLogService
    {
        Task<PaginatedResult<EventLog>> GetAllAsync(GetEventLogsRequest request);

        Task<Result<string>> LogCustomEventAsync(LogEventRequest request);
    }
}