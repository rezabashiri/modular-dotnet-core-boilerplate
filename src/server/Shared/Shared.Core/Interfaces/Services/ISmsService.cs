// --------------------------------------------------------------------------------------------------
// <copyright file="ISmsService.cs" company="">
// Copyright (c) . All rights reserved.
// The core team: Reza Bashiri.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------

using System.Threading.Tasks;
using Shared.DTOs.Sms;

namespace Shared.Core.Interfaces.Services
{
    public interface ISmsService
    {
        Task SendAsync(SmsRequest request);
    }
}