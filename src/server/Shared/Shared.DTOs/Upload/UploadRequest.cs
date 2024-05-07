// --------------------------------------------------------------------------------------------------
// <copyright file="UploadRequest.cs" company="">
// Copyright (c) . All rights reserved.
// The core team: Reza Bashiri.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------

namespace Shared.DTOs.Upload
{
    public class UploadRequest
    {
        public string FileName { get; set; }

        public string Extension { get; set; }

        public UploadType UploadType { get; set; }

        public string Data { get; set; }
    }
}