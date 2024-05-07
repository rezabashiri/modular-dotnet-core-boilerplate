// --------------------------------------------------------------------------------------------------
// <copyright file="AddExtendedAttributeCommand.cs" company="">
// Copyright (c) . All rights reserved.
// The core team: Reza Bashiri.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------

#nullable enable
#pragma warning disable 8618

using System;
using MediatR;
using Shared.Core.Contracts;
using Shared.Core.Wrapper;
using Shared.DTOs.ExtendedAttributes;

namespace Shared.Core.Features.ExtendedAttributes.Commands
{
    // ReSharper disable once UnusedTypeParameter
    public class AddExtendedAttributeCommand<TEntityId, TEntity> : IRequest<Result<Guid>>
        where TEntity : class, IEntity<TEntityId>
    {
        public TEntityId EntityId { get; set; }

        public ExtendedAttributeType Type { get; set; }

        public string Key { get; set; }

        public decimal? Decimal { get; set; }

        public string? Text { get; set; }

        public DateTime? DateTime { get; set; }

        public string? Json { get; set; }

        public bool? Boolean { get; set; }

        public int? Integer { get; set; }

        public string? ExternalId { get; set; }

        public string? Group { get; set; }

        public string? Description { get; set; }

        public bool IsActive { get; set; } = true;
    }
}