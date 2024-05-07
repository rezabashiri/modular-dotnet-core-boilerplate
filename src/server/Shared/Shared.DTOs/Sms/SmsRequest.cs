// --------------------------------------------------------------------------------------------------
// <copyright file="SmsRequest.cs" company="">
// Copyright (c) . All rights reserved.
// The core team: Reza Bashiri.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------

namespace Shared.DTOs.Sms
{
    public class SmsRequest
    {
        public string Number { get; set; }

        public string Message { get; set; }
    }
}