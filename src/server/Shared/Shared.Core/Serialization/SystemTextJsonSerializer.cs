// --------------------------------------------------------------------------------------------------
// <copyright file="SystemTextJsonSerializer.cs" company="">
// Copyright (c) . All rights reserved.
// The core team: Reza Bashiri.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------

using System;
using System.Text.Json;
using Microsoft.Extensions.Options;
using Shared.Core.Interfaces.Serialization;

namespace Shared.Core.Serialization
{
    public class SystemTextJsonSerializer : IJsonSerializer
    {
        private readonly JsonSerializerOptions _options;

        public SystemTextJsonSerializer(IOptions<JsonSerializerSettingsOptions> options)
        {
            _options = options.Value.JsonSerializerOptions;
        }

        public T Deserialize<T>(string data, IJsonSerializerSettingsOptions options = null)
            => JsonSerializer.Deserialize<T>(data, options?.JsonSerializerOptions ?? _options);

        public string Serialize<T>(T data, IJsonSerializerSettingsOptions options = null)
            => JsonSerializer.Serialize(data, options?.JsonSerializerOptions ?? _options);

        public string Serialize<T>(T data, Type type, IJsonSerializerSettingsOptions options = null)
            => JsonSerializer.Serialize(data, type, options?.JsonSerializerOptions ?? _options);
    }
}