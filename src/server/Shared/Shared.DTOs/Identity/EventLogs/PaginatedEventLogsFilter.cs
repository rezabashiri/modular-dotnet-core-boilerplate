// --------------------------------------------------------------------------------------------------
// <copyright file="PaginatedEventLogsFilter.cs" company="">
// Copyright (c) . All rights reserved.
// The core team: Reza Bashiri.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------

#nullable enable
using System;
using Shared.DTOs.Filters;

namespace Shared.DTOs.Identity.EventLogs
{
    public class PaginatedEventLogsFilter : PaginatedFilter
    {
        public string? SearchString { get; set; }

        public Guid UserId { get; set; }

        public string? Email { get; set; }

        public string? MessageType { get; set; }
    }
}