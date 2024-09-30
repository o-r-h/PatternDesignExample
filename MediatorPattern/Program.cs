using MediatorPattern.Classes;
using MediatR;
using Microsoft.Extensions.DependencyInjection;


class Program
{
	static async Task Main(string[] args)
	{
		// Configura el proveedor de servicios
		var services = new ServiceCollection();
		  // Agregar MediatR
		services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

		// Construir el contenedor de servicios
		var serviceProvider = services.BuildServiceProvider();

		// Obtener una instancia de IMediator
		var mediator = serviceProvider.GetRequiredService<IMediator>();

		// Simulación de entrada de usuario
		Console.WriteLine("Ingrese su nombre:");
		string name = Console.ReadLine()??"";

		// Enviar la consulta al Mediator, recordar que el GetWelcomeMessageQuery tiene IRequest del Mediator
		var query = new GetWelcomeMessageQuery(name);
		var message = await mediator.Send(query);

		// Mostrar el resultado
		Console.WriteLine(message);
	}
}


