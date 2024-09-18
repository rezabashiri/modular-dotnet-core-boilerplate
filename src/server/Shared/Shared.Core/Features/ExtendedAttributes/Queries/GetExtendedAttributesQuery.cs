// --------------------------------------------------------------------------------------------------
// <copyright file="GetExtendedAttributesQuery.cs" company="">
// Copyright (c) . All rights reserved.
// The core team: Reza Bashiri.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------

#nullable enable

using MediatR;
using Shared.Core.Contracts;
using Shared.Core.Features.ExtendedAttributes.Filters;
using Shared.Core.Mappings.Converters;
using Shared.Core.Wrapper;
using Shared.DTOs.ExtendedAttributes;

namespace Shared.Core.Features.ExtendedAttributes.Queries
{
    public class GetExtendedAttributesQuery<TEntityId, TEntity>(
        PaginatedExtendedAttributeFilter<TEntityId, TEntity> filter)
        : IRequest<PaginatedResult<GetExtendedAttributesResponse<TEntityId>>>
        where TEntity : class, IEntity<TEntityId>
    {
        public int PageNumber { get; } = filter.PageNumber;

        public int PageSize { get; } = filter.PageSize;

        public string? SearchString { get; } = filter.SearchString;

        public string[] OrderBy { get; } = new OrderByConverter().Convert(filter.OrderBy);

        public TEntityId? EntityId { get; } = filter.EntityId;

        public ExtendedAttributeType? Type { get; } = filter.Type;
    }
}