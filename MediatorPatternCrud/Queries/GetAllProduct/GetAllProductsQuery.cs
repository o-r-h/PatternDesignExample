using MediatorPatternCrud.Classes;
using MediatR;

namespace MediatorPatternCrud.Queries.GetAllProduct
{
    public class GetAllProductsQuery : IRequest<List<Product>>
    {

    }
}
