﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using SchoolProjectCore.Base;

namespace SchoolProjectCore.Behavior
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                var context= new ValidationContext<TRequest>( request);
                var validationResult=await Task.WhenAll(_validators.Select(v =>v.ValidateAsync(context,cancellationToken )));
                var failures=validationResult.SelectMany(r=>r.Errors).Where(f=>f!=null).ToList();
                if (failures.Any())
                {
                    var message=failures.Select(x=>x.PropertyName+" : "+ x.ErrorMessage).FirstOrDefault();
                    throw new ValidationException(message);
                }
            }
            return await next();    
        }
    }
}
