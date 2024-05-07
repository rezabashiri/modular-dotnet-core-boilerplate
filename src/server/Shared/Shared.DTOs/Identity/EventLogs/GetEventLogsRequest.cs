// --------------------------------------------------------------------------------------------------
// <copyright file="GetEventLogsRequest.cs" company="">
// Copyright (c) . All rights reserved.
// The core team: Reza Bashiri.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------

#nullable enable
using System;

namespace Shared.DTOs.Identity.EventLogs
{
    public class GetEventLogsRequest
    {
        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public string? SearchString { get; set; }

        public string[]? OrderBy { get; set; }

        public Guid UserId { get; set; }

        public string? Email { get; set; }

        public string? MessageType { get; set; }
    }
}