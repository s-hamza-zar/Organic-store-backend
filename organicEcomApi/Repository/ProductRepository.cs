using organicEcomApi.Data;
using organicEcomApi.Interfaces;
using organicEcomApi.Models;

namespace organicEcomApi.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ICollection<Product> GetAllProducts()
        {
            return _dbContext.Products.ToList();
        }

        public Product GetProductById(int id)
        {
            return _dbContext.Products.Where(p => p.Id == id).FirstOrDefault();
        }

        public bool ProductExists(int ProductId)
        {
            return _dbContext.Products.Any(p => p.Id == ProductId);
        }

        public bool Save()
        {

            var saved = _dbContext.SaveChanges();

            return saved > 0 ? true : false;
        }

        public bool CreateProduct(int CategoryId, Product product)
        {
            var categoryEntity = _dbContext.Categories.Where(c => c.Id == CategoryId).FirstOrDefault();

            var productCategory = new ProductCategory()
            {
                Product = product,
                Category = categoryEntity
            };

            _dbContext.Add(productCategory);

            _dbContext.Add(product);

            return Save();
        }

        public bool DeleteProduct(int ProductId)
        {
            var productDeleted = _dbContext.Products.Where(p => p.Id == ProductId).FirstOrDefault();

            _dbContext.Remove(productDeleted);

            return Save();
        }

        public bool UpdateProduct(Product product)
        {
            _dbContext.Update(product);

            return Save();
        }
    }
}
