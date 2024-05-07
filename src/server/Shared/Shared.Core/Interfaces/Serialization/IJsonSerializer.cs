// --------------------------------------------------------------------------------------------------
// <copyright file="IJsonSerializer.cs" company="">
// Copyright (c) . All rights reserved.
// The core team: Reza Bashiri.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------

using System;

namespace Shared.Core.Interfaces.Serialization
{
    public interface IJsonSerializer
    {
        string Serialize<T>(T obj, IJsonSerializerSettingsOptions settings = null);

        string Serialize<T>(T obj, Type type, IJsonSerializerSettingsOptions settings = null);

        T Deserialize<T>(string text, IJsonSerializerSettingsOptions settings = null);
    }
}