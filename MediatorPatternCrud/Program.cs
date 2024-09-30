
using MediatorPatternCrud.Behaviours;
using MediatorPatternCrud.Commands.CreateProduct;
using MediatorPatternCrud.Commands.DeleteProduct;
using MediatorPatternCrud.Commands.UpdateProduct;
using MediatorPatternCrud.Queries.GetAllProduct;
using MediatorPatternCrud.Repository;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System.Reflection;
using FluentValidation;

class Program
{

	static async Task Main(string[] args)
	{

		Log.Logger = new LoggerConfiguration()
			   .WriteTo.Console()
			   .CreateLogger();


		var services = new ServiceCollection()

		//Serilog
		.AddSingleton(Log.Logger)
		
		//Repository
		.AddSingleton<IProductRepository, ProductRepository>() // Registra el repositorio en memoria

		//mediaTr
		.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly())) 
		
		//pipeline error handle behaviour
		.AddTransient(typeof(IPipelineBehavior<,>), typeof(ErrorHandlingBehavior<,>))
		
		//pipeline validation behaviour
		.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>))

		// Registrar validadores de FluentValidation
		.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly()) 


		.BuildServiceProvider();



		// Get IMediator instance
		var mediator = services.GetRequiredService<IMediator>();

		// Create products
		await mediator.Send(new CreateProductCommand("Laptop", 1200));
		await mediator.Send(new CreateProductCommand("Smartphone", 800));

		// Get all products
		var products = await mediator.Send(new GetAllProductsQuery());
		Console.WriteLine("Products Stock:");
		products.ForEach(p => Console.WriteLine($"{p.Id}: {p.Name} - {p.Price}"));

		// Update product
		await mediator.Send(new UpdateProductCommand(1, "Laptop Gaming", 1500));

		// Delete product
		await mediator.Send(new DeleteProductCommand(2));

		// Get all products final
		products = await mediator.Send(new GetAllProductsQuery());
		Console.WriteLine("\nProducts Stock final:");
		products.ForEach(p => Console.WriteLine($"{p.Id}: {p.Name} - {p.Price}"));


		



		//Testing
		var servicesTesting = new ServiceCollection();
		servicesTesting.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
		var serviceProvider = servicesTesting.BuildServiceProvider();
		//Testing MediaTR
		using (serviceProvider)
		{
			var result = await mediator.Send(new PingCommand());
			Console.WriteLine($"Ping..{result}");
		}



		// Ejecutar un ejemplo que desencadene validaciones
		
		try
		{
			await mediator.Send(new CreateProductCommand("", 0));
		}
		catch (ValidationException ex)
		{
			Log.Error(ex, "Ocurrieron errores de validación.");
		}
		catch (Exception ex)
		{
			Log.Error(ex, "Ocurrió una excepción al enviar el comando.");
		}
		finally
		{
			Log.CloseAndFlush();
		}







		//Example error exception
		//try
		//{
		//	using (serviceProvider)
		//	{
		//		var result = await mediator.Send(new TestErrorCommand());
		//		Console.WriteLine($"Ping..{result}");
		//	}
		//}
		//catch (Exception ex)
		//{
		//	Log.Error(ex, "Excepción sending command.");
		//}
		//finally
		//{
		//	Log.CloseAndFlush();
		//}
	}

	
	public class PingCommand : IRequest<string> { }
	public class PingCommandHandler : IRequestHandler<PingCommand, string> 
	{
		public Task<string> Handle(PingCommand request, CancellationToken cancellationToken)
		{
			return Task.FromResult("Pong");
		}
	}


	public class TestErrorCommand : IRequest<string> { }
	public class TestErrorCommandHandler : IRequestHandler<TestErrorCommand, string>
	{
		public Task<string> Handle(TestErrorCommand request, CancellationToken cancellationToken)
		{
			int x = 1 / Convert.ToInt32("0");
			return Task.FromResult("Error");
		}
	}



}