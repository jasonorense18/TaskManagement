using ErrorOr;
using FluentValidation;
using MediatR;

namespace TaskManagement.Application.Common.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse> :
        IPipelineBehavior<TRequest, TResponse>
            where TRequest : IRequest<TResponse>
            where TResponse : IErrorOr
    {
        private readonly IValidator<TRequest>? _validator;

        public ValidationBehavior(IValidator<TRequest>? validator = null)
        {
            _validator = validator;
        }

        public async Task<TResponse> Handle(
            TRequest request,
            CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next
            )
        {
            // before the handler

            if (_validator is null)
            {
                return await next();
            }

            var validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (validationResult.IsValid)
            {
                //Call the handler
                return await next();
            }

            var errors = validationResult.Errors
                .ConvertAll(validationFailure => Error.Validation(
                    code: validationFailure.PropertyName,
                    description: validationFailure.ErrorMessage));

            // after the handler
            // No explicit converter of TResponse to ErrorOr
            // The solution is to convert to dynamic
            // This will check runtime if there's a way to covert this to list of errors
            // else it will throw a runtime exception
            // Normally we dont use dynamic keyword it is dangerous because of this
            // But if you always arriving with the list of errors that you cant convert to
            // ErrorOr object then it is fine
            // If throws an exception will go to ErrorController and check for the stack trace\
            return (dynamic)errors;
        }
    }
}
