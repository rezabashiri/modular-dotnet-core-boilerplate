// --------------------------------------------------------------------------------------------------
// <copyright file="CustomValidationException.cs" company="">
// Copyright (c) . All rights reserved.
// The core team: Reza Bashiri.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------

using Microsoft.Extensions.Localization;
using System.Net;

namespace Shared.Core.Exceptions
{
    public class CustomValidationException : CustomException
    {
        public CustomValidationException(IStringLocalizer localizer, List<string> errors)
            : base(localizer["One or more validation failures have occurred."], errors, HttpStatusCode.BadRequest)
        {
        }
    }
}