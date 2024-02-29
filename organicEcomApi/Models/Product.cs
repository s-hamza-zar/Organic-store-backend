using Microsoft.AspNetCore.Mvc;

namespace organicEcomApi.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public string ProductImage { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdated { get; set; }

        public ICollection<Review> Reviews { get; set; }

        public ICollection<ProductCategory> ProductCategories { get; set; }


    }
}
