// --------------------------------------------------------------------------------------------------
// <copyright file="IUploadService.cs" company="">
// Copyright (c) . All rights reserved.
// The core team: Reza Bashiri.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------

using System.Threading.Tasks;
using Shared.DTOs.Upload;

namespace Shared.Core.Interfaces.Services
{
    public interface IUploadService
    {
        Task<string> UploadAsync(UploadRequest request);
    }
}