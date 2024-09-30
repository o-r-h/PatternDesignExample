using MediatorPatternCrud.Classes;
using MediatorPatternCrud.Repository;
using MediatR;


namespace MediatorPatternCrud.Queries.GetAllProduct
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, List<Product>>
    {
        private readonly IProductRepository _repository;

        public GetAllProductsHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAll();
        }
    }
}
