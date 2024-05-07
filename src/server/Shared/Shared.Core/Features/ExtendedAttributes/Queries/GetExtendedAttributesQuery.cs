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
    public class GetExtendedAttributesQuery<TEntityId, TEntity> : IRequest<PaginatedResult<GetExtendedAttributesResponse<TEntityId>>>
        where TEntity : class, IEntity<TEntityId>
    {
        public int PageNumber { get; }

        public int PageSize { get; }

        public string? SearchString { get; }

        public string[] OrderBy { get; }

        public TEntityId? EntityId { get; }

        public ExtendedAttributeType? Type { get; }

        public GetExtendedAttributesQuery(PaginatedExtendedAttributeFilter<TEntityId, TEntity> filter)
        {
            PageNumber = filter.PageNumber;
            PageSize = filter.PageSize;
            SearchString = filter.SearchString;
            OrderBy = new OrderByConverter().Convert(filter.OrderBy);
            EntityId = filter.EntityId;
            Type = filter.Type;
        }
    }
}