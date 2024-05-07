// --------------------------------------------------------------------------------------------------
// <copyright file="MailSettings.cs" company="">
// Copyright (c) . All rights reserved.
// The core team: Reza Bashiri.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------

namespace Shared.Core.Settings
{
    public class MailSettings
    {
        public string From { get; set; }

        public string Host { get; set; }

        public int Port { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string DisplayName { get; set; }

        public bool EnableVerification { get; set; }
    }
}