using MediatR;
namespace MediatorPatternCrud.Commands.CreateProduct
{ 
	public class CreateProductCommand : IRequest<Unit>
	{
		public string Name { get; set; }
		public decimal Price { get; set; }

		public CreateProductCommand(string name, decimal price)
		{
			Name = name;
			Price = price;
		}
	}

}