// --------------------------------------------------------------------------------------------------
// <copyright file="SmsSettings.cs" company="">
// Copyright (c) . All rights reserved.
// The core team: Reza Bashiri.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------

namespace Shared.Core.Settings
{
    public class SmsSettings
    {
        public string SmsAccountIdentification { get; set; }

        public string SmsAccountPassword { get; set; }

        public string SmsAccountFrom { get; set; }

        public bool EnableVerification { get; set; }
    }
}