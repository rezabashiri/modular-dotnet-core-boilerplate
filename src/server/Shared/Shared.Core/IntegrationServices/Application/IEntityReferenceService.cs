// --------------------------------------------------------------------------------------------------
// <copyright file="IEntityReferenceService.cs" company="">
// Copyright (c) . All rights reserved.
// The core team: Reza Bashiri.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------

using System.Threading.Tasks;

namespace Shared.Core.IntegrationServices.Application
{
    public interface IEntityReferenceService
    {
        public Task<string> TrackAsync(string entityName);
    }
}