// --------------------------------------------------------------------------------------------------
// <copyright file="LogEventRequest.cs" company="">
// Copyright (c) . All rights reserved.
// The core team: Reza Bashiri.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------

using System;

namespace Shared.DTOs.Identity.EventLogs
{
    public class LogEventRequest
    {
        public LogEventRequest()
        {
        }

        public string Event { get; set; }

        public string Description { get; set; }

        public string Email { get; set; }

        public Guid UserId { get; set; }
    }
}