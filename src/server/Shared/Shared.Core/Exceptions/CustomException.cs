// --------------------------------------------------------------------------------------------------
// <copyright file="CustomException.cs" company="">
// Copyright (c) . All rights reserved.
// The core team: Reza Bashiri.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Net;

namespace Shared.Core.Exceptions
{
    public class CustomException : Exception
    {
        public List<string> ErrorMessages { get; } = new();

        public HttpStatusCode StatusCode { get; }

        public CustomException(string message, List<string> errors = default, HttpStatusCode statusCode = HttpStatusCode.InternalServerError)
            : base(message)
        {
            ErrorMessages = errors;
            StatusCode = statusCode;
        }
    }
}