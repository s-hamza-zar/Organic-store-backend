using organicEcomApi.Models;

namespace organicEcomApi.Interfaces
{
    public interface IProductRepository
    {
        ICollection<Product> GetAllProducts();

        Product GetProductById(int id);

        bool ProductExists(int ProductId);

        bool CreateProduct(int CategoryId, Product product);

        bool UpdateProduct(Product product);

        bool DeleteProduct(int ProductId);
        bool Save();

    }
}
