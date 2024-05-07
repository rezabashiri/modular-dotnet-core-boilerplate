// --------------------------------------------------------------------------------------------------
// <copyright file="PersistenceSettings.cs" company="">
// Copyright (c) . All rights reserved.
// The core team: Reza Bashiri.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------

namespace Shared.Core.Settings
{
    public class PersistenceSettings
    {
        public bool UseMsSql { get; set; }

        public bool UsePostgres { get; set; }

        public bool UseInMemory { get; set; }

        public PersistenceConnectionStrings ConnectionStrings { get; set; }

        public class PersistenceConnectionStrings
        {
            // ReSharper disable once InconsistentNaming
            public string MSSQL { get; set; }

            public string Postgres { get; set; }
        }
    }
}