
using MediatorPattern.Classes;
using MediatR;

namespace MediatorPattern.Handlers
{
	public class GetWelcomeMessageHandler : IRequestHandler<GetWelcomeMessageQuery, string>
	{
		public Task<string> Handle(GetWelcomeMessageQuery request, CancellationToken cancellationToken)
		{
			return Task.FromResult($"Welcome, {request.Name} ");
		}

		
	}
}
