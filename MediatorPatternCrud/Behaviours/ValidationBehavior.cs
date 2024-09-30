using FluentValidation;
using MediatR;
using Serilog;

namespace MediatorPatternCrud.Behaviours
{
	public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
	{
		private readonly IEnumerable<IValidator<TRequest>> _validators;
		private readonly ILogger _logger;

		public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators, ILogger logger)
		{
			_validators = validators;
			_logger = logger;
		}

		public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
		{
			var context = new ValidationContext<TRequest>(request);

			// Ejecutar todas las validaciones asociadas al comando o consulta
			var failures = _validators
				.Select(v => v.Validate(context))
				.SelectMany(result => result.Errors)
				.Where(f => f != null)
				.ToList();

			if (failures.Any())
			{
				// Loguear los errores de validación
				_logger.Error("Errores de validación para {RequestName}: {Errors}", typeof(TRequest).Name, failures);

				throw new ValidationException(failures);
			}

			// Pasar al siguiente manejador si no hay errores
			return await next();
		}
	}
}
