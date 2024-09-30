using MediatR;


namespace MediatorPattern.Classes
{
	public class GetWelcomeMessageQuery: IRequest<string>
	{
	
		public string Name{ get; set; }

		public GetWelcomeMessageQuery(string name)
		{
			Name = name;
		}


	}
}
