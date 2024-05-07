// --------------------------------------------------------------------------------------------------
// <copyright file="UploadType.cs" company="">
// Copyright (c) . All rights reserved.
// The core team: Reza Bashiri.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------

using System.ComponentModel;

namespace Shared.DTOs.Upload
{
    public enum UploadType
    {
        [Description(@"Images\Catalog\Products")]
        Product,

        [Description(@"Images\Catalog\Brands")]
        Brand,

        [Description(@"Images\Catalog\Categories")]
        Category,

        [Description(@"Images\People\Customers")]
        Customer
    }
}