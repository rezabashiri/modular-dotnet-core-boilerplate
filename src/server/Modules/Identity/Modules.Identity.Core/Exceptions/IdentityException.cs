// --------------------------------------------------------------------------------------------------
// <copyright file="IdentityException.cs" company="">
// Copyright (c) . All rights reserved.
// The core team: Reza Bashiri.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Net;
using Shared.Core.Exceptions;

namespace Modules.Identity.Core.Exceptions
{
    public class IdentityException : CustomException
    {
        public IdentityException(string message, List<string> errors = default, HttpStatusCode statusCode = default)
            : base(message, errors, statusCode)
        {
        }
    }
}