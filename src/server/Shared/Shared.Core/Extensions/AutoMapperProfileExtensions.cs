// --------------------------------------------------------------------------------------------------
// <copyright file="AutoMapperProfileExtensions.cs" company="">
// Copyright (c) . All rights reserved.
// The core team: Reza Bashiri.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------

using System;
using System.Linq;
using System.Reflection;
using AutoMapper;
using Shared.Core.Domain;
using Shared.Core.Features.Common.Filters;
using Shared.Core.Features.ExtendedAttributes.Commands;
using Shared.Core.Features.ExtendedAttributes.Queries;
using Shared.DTOs.ExtendedAttributes;

namespace Shared.Core.Extensions
{
    public static class AutoMapperProfileExtensions
    {
        public static Profile CreateExtendedAttributesMappings(this Profile profile, Assembly assembly)
        {
            var extendedAttributeTypes = assembly
                .GetExportedTypes()
                .Where(t => t.IsClass && !t.IsAbstract && t.BaseType?.IsGenericType == true)
                .Select(t => new
                {
                    BaseGenericType = t.BaseType,
                    CurrentType = t
                })
                .Where(t => t.BaseGenericType?.GetGenericTypeDefinition() == typeof(ExtendedAttribute<,>))
                .ToList();

            foreach (var extendedAttributeType in extendedAttributeTypes)
            {
                var extendedAttributeTypeGenericArguments = extendedAttributeType.BaseGenericType.GetGenericArguments().ToList();

                #region AddExtendedAttributeCommand

                var sourceType = typeof(AddExtendedAttributeCommand<,>).MakeGenericType(extendedAttributeTypeGenericArguments.ToArray());
                profile.CreateMap(sourceType, extendedAttributeType.CurrentType).ReverseMap();

                #endregion AddExtendedAttributeCommand

                #region UpdateExtendedAttributeCommand

                sourceType = typeof(UpdateExtendedAttributeCommand<,>).MakeGenericType(extendedAttributeTypeGenericArguments.ToArray());
                profile.CreateMap(sourceType, extendedAttributeType.CurrentType).ReverseMap();

                #endregion UpdateExtendedAttributeCommand

                #region GetExtendedAttributeByIdQuery

                var baseExtendedAttributeType = typeof(ExtendedAttribute<,>).MakeGenericType(extendedAttributeTypeGenericArguments.ToArray());
                sourceType = typeof(GetByIdCacheableFilter<,>).MakeGenericType(typeof(Guid), baseExtendedAttributeType);
                var destinationType = typeof(GetExtendedAttributeByIdQuery<,>).MakeGenericType(extendedAttributeTypeGenericArguments.ToArray());
                profile.CreateMap(sourceType, destinationType);

                #endregion GetExtendedAttributeByIdQuery

                #region GetExtendedAttributeByIdResponse

                sourceType = typeof(GetExtendedAttributeByIdResponse<>).MakeGenericType(extendedAttributeTypeGenericArguments[0]);
                profile.CreateMap(sourceType, extendedAttributeType.CurrentType).ReverseMap();

                #endregion GetExtendedAttributeByIdResponse

                #region GetExtendedAttributesResponse

                sourceType = typeof(GetExtendedAttributesResponse<>).MakeGenericType(extendedAttributeTypeGenericArguments[0]);
                profile.CreateMap(sourceType, extendedAttributeType.CurrentType).ReverseMap();

                #endregion GetExtendedAttributesResponse
            }

            return profile;
        }
    }
}