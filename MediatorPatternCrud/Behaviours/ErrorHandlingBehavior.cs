using MediatR;
using Serilog;


namespace MediatorPatternCrud.Behaviours
{
	public class ErrorHandlingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
	{
		private readonly ILogger _logger;

		public ErrorHandlingBehavior(ILogger logger)
		{
			_logger = logger;
		}

		public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
		{
			try
			{
				//try next chain handle.
				return await next();
			}
			catch (Exception ex)
			{
				//log the exception with  Serilog.
				_logger.Error(ex, "xxx Error proccessing {RequestName} with data {@Request}", typeof(TRequest).Name, request);

				//throw the exception.
				throw;
			}
		}
	}
}
