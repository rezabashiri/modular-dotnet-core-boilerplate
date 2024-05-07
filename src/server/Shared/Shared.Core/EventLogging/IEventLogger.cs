// --------------------------------------------------------------------------------------------------
// <copyright file="IEventLogger.cs" company="">
// Copyright (c) . All rights reserved.
// The core team: Reza Bashiri.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------

using System.Threading.Tasks;
using Shared.Core.Domain;

namespace Shared.Core.EventLogging
{
    public interface IEventLogger
    {
        Task SaveAsync<T>(T @event, (string oldValues, string newValues) changes)
            where T : Event;
    }
}