// --------------------------------------------------------------------------------------------------
// <copyright file="JwtSettings.cs" company="">
// Copyright (c) . All rights reserved.
// The core team: Reza Bashiri.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------

namespace Modules.Identity.Core.Settings
{
    public class JwtSettings
    {
        public string Key { get; set; }

        public int TokenExpirationInMinutes { get; set; }

        public int RefreshTokenExpirationInDays { get; set; }
    }
}