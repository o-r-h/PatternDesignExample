using MediatorPatternCrud.Classes;

namespace MediatorPatternCrud.Repository
{
	public class ProductRepository : IProductRepository
	{
		private readonly List<Product> _products = new();

		public Task<List<Product>> GetAll() => Task.FromResult(_products);

		public Task<Product> GetById(int id) =>
			Task.FromResult(_products.FirstOrDefault(p => p.Id == id));

		public Task Create(Product product)
		{
			product.Id = _products.Count + 1;  // Simulamos un auto-incremento de ID
			_products.Add(product);
			return Task.CompletedTask;
		}

		public Task Update(Product product)
		{
			var prod = _products.FirstOrDefault(p => p.Id == product.Id);
			if (prod != null)
			{
				prod.Name = product.Name;
				prod.Price = product.Price;
			}
			return Task.CompletedTask;
		}

		public Task Delete(int id)
		{
			var product = _products.FirstOrDefault(p => p.Id == id);
			if (product != null)
			{
				_products.Remove(product);
			}
			return Task.CompletedTask;
		}
	}
}
