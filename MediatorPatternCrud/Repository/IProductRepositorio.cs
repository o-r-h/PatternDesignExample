using MediatorPatternCrud.Classes;

namespace MediatorPatternCrud.Repository
{
	public interface IProductRepository
	{
		Task Create(Product product);
		Task Delete(int id);
		Task<List<Product>> GetAll();
		Task<Product> GetById(int id);
		Task Update(Product product);
	}
}