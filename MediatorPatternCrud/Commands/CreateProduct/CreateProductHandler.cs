using MediatorPatternCrud.Classes;
using MediatorPatternCrud.Repository;
using MediatR;

namespace MediatorPatternCrud.Commands.CreateProduct
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, Unit>
    {
        private readonly IProductRepository _repository;

        public CreateProductHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {

            var product = new Product
            {
                Name = request.Name,
                Price = request.Price
            };
            await _repository.Create(product);
            return Unit.Value;
        }
    }
}
