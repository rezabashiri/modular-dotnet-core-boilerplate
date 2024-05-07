// --------------------------------------------------------------------------------------------------
// <copyright file="MailRequest.cs" company="">
// Copyright (c) . All rights reserved.
// The core team: Reza Bashiri.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------

namespace Shared.DTOs.Mails
{
    public class MailRequest
    {
        public string To { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        public string From { get; set; }
    }
}