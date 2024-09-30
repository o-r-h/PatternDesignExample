using MediatorPatternCrud.Classes;
using MediatorPatternCrud.Repository;
using MediatR;

namespace MediatorPatternCrud.Commands.UpdateProduct
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, Unit>
    {
        private readonly IProductRepository _repository;

        public UpdateProductHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Id = request.Id,
                Name = request.Name,
                Price = request.Price
            };
            await _repository.Update(product);
            return Unit.Value;
        }
    }
}
