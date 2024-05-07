// --------------------------------------------------------------------------------------------------
// <copyright file="ValidationBehavior.cs" company="">
// Copyright (c) . All rights reserved.
// The core team: Reza Bashiri.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------

using FluentValidation;
using MediatR;
using Microsoft.Extensions.Localization;
using Shared.Core.Exceptions;

namespace Shared.Core.Behaviors
{
    public class ValidationBehavior
    {
        // for localization
    }

    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
         where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        private readonly IStringLocalizer<ValidationBehavior> _localizer;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators, IStringLocalizer<ValidationBehavior> localizer)
        {
            _validators = validators;
            _localizer = localizer;
        }

#pragma warning disable RCS1046 // Asynchronous method name should end with 'Async'.
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
#pragma warning restore RCS1046 // Asynchronous method name should end with 'Async'.

        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);
                var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
                var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

                if (failures.Count != 0)
                {
                    var errorMessages = failures.Select(a => a.ErrorMessage).Distinct().ToList();
                    throw new CustomValidationException(_localizer, errorMessages);
                }
            }

            return await next();
        }
    }
}